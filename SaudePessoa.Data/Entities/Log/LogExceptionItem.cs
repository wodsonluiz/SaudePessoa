using System;
using System.Collections.Generic;
using System.Text;

namespace SaudePessoa.Data.Entities.Log
{
    public class LogExceptionItem
    {
        public int Id { get; set; }
        public string objectItem { get; set; }
        public DateTime Data { get; set; }
        public string MethodItem { get; set; }
        public string InnerDescricao { get; set; }
    }
}
