namespace Oho.Common.Auth
{
    using System;

    public interface IJwtHandler
    {
        JsonWebToken Create(Guid userId);
    }
}