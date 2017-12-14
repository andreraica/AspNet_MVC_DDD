using Budget.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Budget.Infrastructure.Stub
{
    public static class ItemValorStub
    {
        public static ItemValor NovoItemValor()
        {
            var itemValor = new ItemValor()
            {
                ID = 99,
                Vencimento = DateTime.Now,
                Orcamento = OrcamentoStub.Receita(),
                SubValores = ItemSubValorStub.ItemSubValores()
            };

            itemValor.SubValores.Add(new ItemSubValor() { ID = 1, Valor = 123.45M, });

            return itemValor;
        }

        public static ItemValor ItemValor()
        {
            var itemValor = new ItemValor()
            {
                ID = 1,
                Vencimento = new System.DateTime(2014, 01, 13)
            };

            itemValor.SubValores = new List<ItemSubValor>();
            itemValor.SubValores.Add(new ItemSubValor() { ID = 1, Valor = 100M, });
            
            return itemValor;
        }

        public static List<ItemValor> ItemValores()
        {
            var itensValores = new List<ItemValor>();

            itensValores.Add(
                ItemValor()
            );

            itensValores.Add(
                new ItemValor()
                {
                    ID = 2,
                    Vencimento = new System.DateTime(2014, 02, 15)
                }
            );

            itensValores[1].SubValores = new List<ItemSubValor>();
            itensValores[1].SubValores.Add(new ItemSubValor() { ID = 2, Valor = 1000M, });
            
            itensValores.Add(
                new ItemValor()
                {
                    ID = 3,
                    Vencimento = new System.DateTime(2014, 03, 23)
                }
            );

            itensValores[2].SubValores = new List<ItemSubValor>();
            itensValores[2].SubValores.Add(new ItemSubValor() { ID = 3, Valor = 250M, });

            return itensValores;
        }
    }
}
