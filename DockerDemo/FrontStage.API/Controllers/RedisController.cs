using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace FrontStage.API.Controllers
{
	[Serializable]
	public class UserModel
	{
		public int Id { get; set; }

		public string Name { get; set; }
	}

    [Route("api/[controller]")]
    [ApiController]
    public class RedisController : ControllerBase
    {
		private IDistributedCache distributedCache;

		public RedisController(IDistributedCache distributedCache)
		{
			this.distributedCache = distributedCache;
		}

		public UserModel GetAsync()
		{
			distributedCache.Set("Sample", ObjectToByteArray(new UserModel()
			{
				Id = 1,
				Name = "John"
			}));
			var model = ByteArrayToObject<UserModel>(distributedCache.Get("Sample"));

			return model;
		}

		private byte[] ObjectToByteArray(object obj)
		{
			var binaryFormatter = new BinaryFormatter();
			using (var memoryStream = new MemoryStream())
			{
				binaryFormatter.Serialize(memoryStream, obj);
				return memoryStream.ToArray();
			}
		}

		private T ByteArrayToObject<T>(byte[] bytes)
		{
			using (var memoryStream = new MemoryStream())
			{
				var binaryFormatter = new BinaryFormatter();
				memoryStream.Write(bytes, 0, bytes.Length);
				memoryStream.Seek(0, SeekOrigin.Begin);
				var obj = binaryFormatter.Deserialize(memoryStream);
				return (T)obj;
			}
		}
	}
}