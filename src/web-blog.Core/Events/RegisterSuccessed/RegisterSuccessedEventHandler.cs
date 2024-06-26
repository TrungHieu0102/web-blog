﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using web_blog.Core.Events.RegisterSuccessed;

namespace web_blog.Core.Events.RegisterSuccessed
{
    internal class RegisterSuccessedEventHandler : INotificationHandler<RegisterSuccessedEvent>
    {
        public Task Handle(RegisterSuccessedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}