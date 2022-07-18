using ClientEvaluation.Domain.Entites;

namespace ClientEvaluation.Tests
{
    [TestClass]
    public class ClientTests
    {
        [TestMethod]
        public void Dado_um_cliente_o_mesmo_deve_ser_valido()
        {
            var client = new Client("Teste Comercial", "Teste Responsável", "34146932000191");
            Assert.IsTrue(client.IsValid);
        }

        [TestMethod]
        public void Dado_um_cliente_seu_nome_deve_ser_validado_existencia()
        {
            var client = new Client(null, "Teste Responsável", "34146932000191");
            Assert.IsFalse(client.IsValid);
        }

        [TestMethod]
        public void Dado_um_cliente_seu_nome_deve_ser_validado_tamanho_minimo()
        {
            var client = new Client("te", "Teste Responsável", "34146932000191");
            Assert.IsFalse(client.IsValid);
        }

        [TestMethod]
        public void Dado_um_cliente_seu_nome_deve_ser_validado_tamanho_maximo()
        {
            var client = new Client("TesteTesteTesteTesteTesteTesteTesteTesteTesteTesteTesteTesteTesteTesteTesteTesteTesteTesteTesteTesteTesteTesteTesteTesteTesteTesteTesteTesteTesteTesteTesteTesteTesteTesteTesteTesteTesteTesteTesteTestee", "Teste Responsável", "34146932000191");
            Assert.IsFalse(client.IsValid);
        }

        [TestMethod]
        public void Dado_um_cliente_seu_nome_comerical_deve_ser_validado()
        {
            var client = new Client("Teste", null, "34146932000191");
            Assert.IsFalse(client.IsValid);
        }

        [TestMethod]
        public void Dado_um_cliente_seu_documento_deve_ser_validado_tamanho()
        {
            var client = new Client("Teste", "Teste", "123");
            Assert.IsFalse(client.IsValid);
        }
    }
}