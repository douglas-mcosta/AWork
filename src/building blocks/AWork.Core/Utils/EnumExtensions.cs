using AWork.Core.DomainObjects.Enums;
using System;

namespace AWork.Core.Utils
{
    public static class EnumExtensions
    {
        public static bool Validate(this FluencyLevel enumValue)
        {

            if (Enum.IsDefined(typeof(FluencyLevel), enumValue))
            {
                return true;
            }
            return false;
        }
    }
}
