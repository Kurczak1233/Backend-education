using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EntiryFramework.Database
{
    public class Setting
    {
        [Key]
        public int Id { get; set; }
        public string Name{ get; set; }
        public string Value { get; set; }
    }
}
