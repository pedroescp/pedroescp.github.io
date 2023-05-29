using System.ComponentModel;
using System.Runtime.Serialization;

namespace uNotes.Infra.CrossCutting.Enums
{
    public enum TipoCriptografia
    {
        [Description("Senha do Tipo Login")]
        [EnumMember(Value = "Senha do Tipo Login")]
        SenhaLogin,
    }
}