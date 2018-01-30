using System;

namespace LandonAPI.Infrastructure
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class SecretAttribute : Attribute
    { }
}
