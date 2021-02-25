using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EntiryFramework.Database
{
    public class Setting
    {
        [Key]
        public string Id { get; set; }
        public string Name{ get; set; }
        public string Value { get; set; }
    }
}
