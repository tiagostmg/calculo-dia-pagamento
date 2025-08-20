namespace src
{
    public class Program
    {
        public static void Main()
        {
            DiaPagamento diaPagamento = new();
            Cliente[] clientes = [
                new Cliente(
                    "tiago", 5
                )
            ];
            var c = diaPagamento.ClientesAPagar(clientes);
            Console.WriteLine(c[0].Nome);
        }
    }
}