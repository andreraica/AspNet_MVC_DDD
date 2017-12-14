using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web.Mvc;

namespace Budget.Infrastructure.Helpers
{
    public static class EnumHelper
    {
        public static string Description(this Enum value)
        {
            return GetCustomDescription(value);
        }
               
        public static IEnumerable<SelectListItem> GetList<T>(T value) where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum)
                throw new ArgumentException("This is for use with enums only!");

            return Enum.GetValues(typeof(T)).Cast<T>().Select(x => 
                new SelectListItem
                            {
                                Value = Convert.ToInt32(x).ToString(),
                                Text = GetCustomDescription(x),
                                Selected = (Convert.ToInt32(x).ToString() == Convert.ToInt32(value).ToString())
                            });
        }

        //public static IEnumerable<SelectListItem> GetList<T>() where T : struct, IConvertible
        //{
        //    return GetList<T>(null);
        //}

        private static string GetCustomDescription(object objEnum)
        {
            var fieldInfo = objEnum.GetType().GetField(objEnum.ToString());
            var attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return (attributes.Length > 0) ? attributes[0].Description : objEnum.ToString();
        }
    }

}
