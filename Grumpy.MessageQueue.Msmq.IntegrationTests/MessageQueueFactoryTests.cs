﻿using FluentAssertions;
using Grumpy.Common;
using Grumpy.MessageQueue.Enum;
using Microsoft.Extensions.Logging.Abstractions;
using Xunit;

namespace Grumpy.MessageQueue.Msmq.IntegrationTests
{
    public class MessageQueueFactoryTests
    {
        [Fact]
        public void MessageQueueFactoryCanCreateLocaleInstance()
        {
            var name = $"IntegrationTest_{UniqueKeyUtility.Generate()}";

            using (var queue = new QueueFactory(NullLogger.Instance).CreateLocale(name, true, LocaleQueueMode.TemporaryMaster, true))
            {
                queue.Should().NotBeNull();
                queue.GetType().Should().Be(typeof(LocaleQueue));
            }
        }
    }
}