﻿namespace ChatRoom.Domain.Commands
{
    public struct ValidationMessages
    {
        public const string Required = "The {PropertyName} field is required.";
        public const string InvalidValue = "The {PropertyName} field value is invalid.";
        public const string MaxLength = "The {PropertyName} maxlength is {MaxLength} characters.";
    }
}
