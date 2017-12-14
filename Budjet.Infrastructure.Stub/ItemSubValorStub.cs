using Budget.Domain.Entities;
using System.Collections.Generic;

namespace Budget.Infrastructure.Stub
{
    public static class ItemSubValorStub
    {
        public static ItemSubValor NovoItemSubValor()
        {
            return new ItemSubValor()
            {
                ID = 99,
                Valor = 78.5M
            };
        }

        public static ItemSubValor ItemSubValor()
        {
            return new ItemSubValor()
            {
                ID = 1,
                Valor = 51
            };
        }

        public static List<ItemSubValor> ItemSubValores()
        {
            var itensValores = new List<ItemSubValor>();

            itensValores.Add(
                ItemSubValor()
            );

            itensValores.Add(
                new ItemSubValor()
                {
                    ID = 2,
                    Valor = 103
                }
            );

            itensValores.Add(
                new ItemSubValor()
                {
                    ID = 3,
                    Valor = 87
                }
            );

            return itensValores;
        }
    }
}
