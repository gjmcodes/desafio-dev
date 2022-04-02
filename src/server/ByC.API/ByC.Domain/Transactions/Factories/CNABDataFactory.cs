using ByC.Domain.Transactions.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ByC.Domain.Transactions.Factories
{
    public static class CNABDataFactory
    {

        private static CNABData type = new CNABData(description: "Tipo da transação", indexStart: 1, indexEnd: 1);
        private static CNABData date = new CNABData(description: "Data da ocorrência", indexStart: 2, indexEnd: 9);
        private static CNABData value = new CNABData(description: "Valor da transação", indexStart: 10, indexEnd: 19);
        private static CNABData document = new CNABData(description: "Documento responsável", indexStart: 20, indexEnd: 30);
        private static CNABData card = new CNABData(description: "Cartão utilizado", indexStart: 31, indexEnd: 42);
        private static CNABData hour = new CNABData(description: "Hora da transação", indexStart: 43, indexEnd: 48);
        private static CNABData storeOwnerName = new CNABData(description: "Nome responsável", indexStart: 49, indexEnd: 62);
        private static CNABData storeName = new CNABData(description: "Nome loja", indexStart: 63, indexEnd: 81);

        public static CNABData Type => type;
        public static CNABData Date => date;
        public static CNABData Value => value;
        public static CNABData Document => document;
        public static CNABData Card => card;
        public static CNABData Hour => hour;
        public static CNABData StoreOwnerName => storeOwnerName;
        public static CNABData StoreName => storeName;

    }
}
