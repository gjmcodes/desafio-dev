using ByC.Domain.Transactions.Entities;
using ByC.Tests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByC.Tests
{
    [TestClass]
    public class TransactionDocumentTest
    {
        [TestMethod]
        public void NewTransaction_Document_IsValid()
        {
            // Arrange

            var cnab = CNABHelpers.validCNAB;

            // Act
            var transaction = new TransactionRoot(cnab);
            var validation = transaction.IsValid();

            // Assert
            Assert.IsTrue(validation.IsValid);
        }

        [TestMethod]
        public void NewTransaction_Document_AllEqual_IsInvalid()
        {
            // Arrange
            var cnab = CNABHelpers.GetCNAB(doc: "00000000000");

            // Act
            var transaction = new TransactionRoot(cnab);
            var validation = transaction.IsValid();

            // Assert
            Assert.IsTrue(validation.IsValid == false);
            Assert.IsTrue(validation.Errors.Any(x => x.PropertyName.ToLower() == "document"));
        }

        [TestMethod]
        public void NewTransaction_Document_Random_IsInvalid()
        {
            // Arrange
            var cnab = CNABHelpers.GetCNAB(doc: "12365478900");

            // Act
            var transaction = new TransactionRoot(cnab);
            var validation = transaction.IsValid();

            // Assert
            Assert.IsTrue(validation.IsValid == false);
            Assert.IsTrue(validation.Errors.Any(x => x.PropertyName.ToLower() == "document"));
        }

        [TestMethod]
        public void NewTransaction_Document_Length_IsInvalid()
        {
            // Arrange
            var cnab = CNABHelpers.GetCNAB(doc: "0123456    ");

            // Act
            var transaction = new TransactionRoot(cnab);
            var validation = transaction.IsValid();

            // Assert
            Assert.IsTrue(validation.IsValid == false);
            Assert.IsTrue(validation.Errors.Any(x => x.PropertyName.ToLower() == "document"));
        }
    }
}
