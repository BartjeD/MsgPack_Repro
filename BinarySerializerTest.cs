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
        private readonly MessagePackSerializerOptions _options = StandardResolver.Options;

        [Fact]
        public async Task Serialize_And_Deserialize_string_Stream_TestAsync()
        {
            var testObject = "test";

            var stream = new MemoryStream();
            await MessagePackSerializer.SerializeAsync(typeof(string), stream, testObject, _options, default).ConfigureAwait(false);

            var deserialized = await MessagePackSerializer.DeserializeAsync<string>(stream, _options, default).ConfigureAwait(false);
            Assert.True(deserialized.Equals(testObject));
        }

        [Fact]
        public async Task Serialize_And_Deserialize_List_Guid_Stream_TestAsync()
        {
            var testObject = new List<Guid>
            {
                Guid.NewGuid(),
                Guid.NewGuid(),
                Guid.NewGuid(),
            };

            var stream = new MemoryStream();
            await MessagePackSerializer.SerializeAsync(typeof(IList<Guid>), stream, testObject, _options, default).ConfigureAwait(false);

            var deserialized = await MessagePackSerializer.DeserializeAsync<IList<Guid>>(stream, _options, default).ConfigureAwait(false);

            Assert.True(deserialized.Count is 3);
        }
    }
}