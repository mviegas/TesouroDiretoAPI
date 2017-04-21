using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;

namespace TesouroDiretoAPI.Common
{
    /// <summary>
    /// Classe de Extensão para Enumerados
    /// </summary>
    public static class EnumExtension
    {
        /// <summary>
        /// Retorna o valor de um Enum a partir do atributo Description
        /// </summary>
        /// <typeparam name="T">Tipo do Enum</typeparam>
        /// <param name="description">Descrição</param>
        /// <returns></returns>
        public static T GetEnumValueFromDescription<T>(string description)
        {
            var type = typeof(T);
            if (!type.GetTypeInfo().IsEnum)
                throw new InvalidOperationException();

            foreach (var field in type.GetFields())
            {
                var attribute = field.GetCustomAttribute<TituloDescriptionAttribute>();

                if (attribute != null)
                {
                    if (description.Contains(attribute.Description))
                        return (T)field.GetValue(null);
                }
                else
                {
                    if (field.Name == description)
                        return (T)field.GetValue(null);
                }
            }

            throw new ArgumentException("Atributo não encontrado.", "Descrição");
        }

        /// <summary>
        /// Retonra a Descrição de um Enumerado decorado com o Atributo Description
        /// </summary>
        /// <param name="owner"></param>
        /// <returns></returns>
        public static String GetDescription(this Enum owner)
        {
            FieldInfo fieldInfo = owner.GetType().GetField(owner.ToString());
            var attribute = fieldInfo.GetCustomAttribute<DescriptionAttribute>();

            if (attribute != null)
                return attribute.Description;
            else
                return owner.ToString();
        }

        /// <summary>
        /// Retonra o Vencimento de um Enumerado decorado com o Atributo TituloDescription
        /// </summary>
        /// <param name="owner"></param>
        /// <returns></returns>
        public static String GetVencimento(this Enum owner)
        {
            FieldInfo fieldInfo = owner.GetType().GetField(owner.ToString());
            var attribute = fieldInfo.GetCustomAttribute<TituloDescriptionAttribute>();

            if (attribute != null)
                return attribute.Vencimento;
            else
                return owner.ToString();
        }
    }
}
