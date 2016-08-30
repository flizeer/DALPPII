using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Pessoa
    {
        public int CdPessoa { get; set; }
        public string NmPessoa { get; set; }
        public string NrCPF { get; set; }
        public DateTime DtNascimento { get; set; }
        public string DsLogradouro { get; set; }
        public string DsCidade { get; set; }
        public string DsUF { get; set; }

    }


}
