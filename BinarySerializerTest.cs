using MessagePack;
using MessagePack.Resolvers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace MsgPack.Repro
{
    public class BinarySerializerTest
    {
        private readonly MessagePackSerializerOptions _standardOptions = StandardResolver.Options;
        private readonly MessagePackSerializerOptions _contractlessOptions = ContractlessStandardResolver.Options;

        [Fact]
        public async Task Standard_Serialize_And_Deserialize_string_Stream_TestAsync()
        {
            var testObject = "test";

            var stream = new MemoryStream();
            await MessagePackSerializer.SerializeAsync(typeof(string), stream, testObject, _standardOptions, default).ConfigureAwait(false);
            stream.Position = 0;

            var deserialized = await MessagePackSerializer.DeserializeAsync<string>(stream, _standardOptions, default).ConfigureAwait(false);
            Assert.True(deserialized.Equals(testObject));
        }

        [Fact]
        public async Task Standard_Serialize_And_Deserialize_string_Bytes_TestAsync()
        {
            var testObject = "test";

            var stream = new MemoryStream();
            await MessagePackSerializer.SerializeAsync(typeof(string), stream, testObject, _standardOptions, default).ConfigureAwait(false);
            stream.Position = 0;

            var deserialized = MessagePackSerializer.Deserialize<string>(stream.ToArray(), _standardOptions, default);
            Assert.True(deserialized.Equals(testObject));
        }

        [Fact]
        public async Task Standard_Serialize_And_Deserialize_List_Guid_Stream_TestAsync()
        {
            var testObject = new List<Guid>
            {
                Guid.NewGuid(),
                Guid.NewGuid(),
                Guid.NewGuid(),
            };

            var stream = new MemoryStream();
            await MessagePackSerializer.SerializeAsync(typeof(IList<Guid>), stream, testObject, _standardOptions, default).ConfigureAwait(false);
            stream.Position = 0;

            var deserialized = await MessagePackSerializer.DeserializeAsync<IList<Guid>>(stream, _standardOptions, default).ConfigureAwait(false);

            Assert.True(deserialized.Count is 3);
        }

        [Fact]
        public async Task Standard_Serialize_And_Deserialize_List_Guid_Bytes_TestAsync()
        {
            var testObject = new List<Guid>
            {
                Guid.NewGuid(),
                Guid.NewGuid(),
                Guid.NewGuid(),
            };

            var stream = new MemoryStream();
            await MessagePackSerializer.SerializeAsync(typeof(IList<Guid>), stream, testObject, _standardOptions, default).ConfigureAwait(false);
            stream.Position = 0;

            var deserialized = MessagePackSerializer.Deserialize<IList<Guid>>(stream.ToArray(), _standardOptions, default);

            Assert.True(deserialized.Count is 3);
        }

        [Fact]
        public async Task Contractless_Serialize_And_Deserialize_string_Stream_TestAsync()
        {
            var testObject = "test";

            var stream = new MemoryStream();
            await MessagePackSerializer.SerializeAsync(typeof(string), stream, testObject, _contractlessOptions, default).ConfigureAwait(false);
            stream.Position = 0;

            var deserialized = await MessagePackSerializer.DeserializeAsync<string>(stream, _contractlessOptions, default).ConfigureAwait(false);
            Assert.True(deserialized.Equals(testObject));
        }

        [Fact]
        public async Task Contractless_Serialize_And_Deserialize_string_Bytes_TestAsync()
        {
            var testObject = "test";

            var stream = new MemoryStream();
            await MessagePackSerializer.SerializeAsync(typeof(string), stream, testObject, _contractlessOptions, default).ConfigureAwait(false);

            var deserialized = MessagePackSerializer.Deserialize<string>(stream.ToArray(), _contractlessOptions, default);
            Assert.True(deserialized.Equals(testObject));
        }

        [Fact]
        public async Task Contractless_Serialize_And_Deserialize_List_Guid_Stream_TestAsync()
        {
            var testObject = new List<Guid>
            {
                Guid.NewGuid(),
                Guid.NewGuid(),
                Guid.NewGuid(),
            };

            var stream = new MemoryStream();
            await MessagePackSerializer.SerializeAsync(typeof(IList<Guid>), stream, testObject, _contractlessOptions, default).ConfigureAwait(false);
            stream.Position = 0;

            var deserialized = await MessagePackSerializer.DeserializeAsync<IList<Guid>>(stream, _contractlessOptions, default).ConfigureAwait(false);

            Assert.True(deserialized.Count is 3);
        }

        [Fact]
        public async Task Contractless_Serialize_And_Deserialize_Wrapper_And_List_Guid_Stream_TestAsync()
        {
            var testObject = new ApiResult<IList<Guid>>
            {
                Result = new List<Guid>
                {
                    Guid.NewGuid(),
                    Guid.NewGuid(),
                    Guid.NewGuid(),
                },
            };

            var stream = new MemoryStream();
            await MessagePackSerializer.SerializeAsync(typeof(ApiResult<IList<Guid>>), stream, testObject, _contractlessOptions, default).ConfigureAwait(false);
            stream.Position = 0;

            var deserialized = await MessagePackSerializer.DeserializeAsync<ApiResult<IList<Guid>>>(stream, _contractlessOptions, default).ConfigureAwait(false);

            Assert.True(deserialized.Result.Count is 3);
        }

        [Fact]
        public async Task Contractless_Serialize_And_Deserialize_List_Guid_Bytes_TestAsync()
        {
            var testObject = new List<Guid>
            {
                Guid.NewGuid(),
                Guid.NewGuid(),
                Guid.NewGuid(),
            };

            var stream = new MemoryStream();
            await MessagePackSerializer.SerializeAsync(typeof(IList<Guid>), stream, testObject, _contractlessOptions, default).ConfigureAwait(false);
            stream.Position = 0;

            var deserialized = MessagePackSerializer.Deserialize<IList<Guid>>(stream.ToArray(), _contractlessOptions, default);

            Assert.True(deserialized.Count is 3);
        }
    }
}