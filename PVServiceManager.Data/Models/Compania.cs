using Newtonsoft.Json;

namespace PVServiceManager.Data.Models;


    public partial class Compania
    {
        [JsonProperty("slogan")]
        public String Slogan { get; set; }

        [JsonProperty("rnc")]
        public String Rnc { get; set; }

        [JsonProperty("telefono")]
        public String Telefono { get; set; }

        [JsonProperty("fax")]
        public String Fax { get; set; }

        [JsonProperty("direccion")]
        public String Direccion { get; set; }

        [JsonProperty("centroCosto")]
        public String CentroCosto { get; set; }

        [JsonProperty("parametro")]
        public String Parametro { get; set; }

        [JsonProperty("sucursal", NullValueHandling = NullValueHandling.Ignore)]
        public long Sucursal { get; set; }

        [JsonProperty("nombre", NullValueHandling = NullValueHandling.Ignore)]
        public string Nombre { get; set; }

        [JsonProperty("tipoIdentificacion", NullValueHandling = NullValueHandling.Ignore)]
        public long? TipoIdentificacion { get; set; }

        [JsonProperty("identificacion")]
        public object Identificacion { get; set; }

        [JsonProperty("tipoEntidad", NullValueHandling = NullValueHandling.Ignore)]
        public TipoEntidad TipoEntidad { get; set; }

        [JsonProperty("correoElectronico")]
        public String CorreoElectronico { get; set; }

        [JsonProperty("sexo", NullValueHandling = NullValueHandling.Ignore)]
        public long? Sexo { get; set; }

        [JsonProperty("fechaNacimiento")]
        public object FechaNacimiento { get; set; }

        [JsonProperty("estadoCivil", NullValueHandling = NullValueHandling.Ignore)]
        public long? EstadoCivil { get; set; }

        [JsonProperty("nota")]
        public String? Nota { get; set; }

        [JsonProperty("activo", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Activo { get; set; }

        [JsonProperty("idExterno", NullValueHandling = NullValueHandling.Ignore)]
        public string IdExterno { get; set; }

        [JsonProperty("codigo", NullValueHandling = NullValueHandling.Ignore)]
        public string Codigo { get; set; }
    }

    public partial class TipoEntidad
    {
        [JsonProperty("nombre")]
        public String? Nombre { get; set; }

        [JsonProperty("codigo")]
        public String? Codigo { get; set; }

        [JsonProperty("idExterno")]
        public long? IdExterno { get; set; }
    }
