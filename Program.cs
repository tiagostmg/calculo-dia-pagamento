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
            PrintClientes(c);

            // int mes = DateTime.Now.Month;
            // int ano = DateTime.Now.Year;
            // DateTime dia9 = new(ano, mes, 9);
            // DateTime a = diaPagamento.SomarDiasUteis(dia9, 7);
            // Console.WriteLine(a);
        }

        public static void PrintClientes(List<Cliente> list)
        {
            foreach (Cliente c in list)
            {
                Console.WriteLine(c.Nome + ": " + c.DiaPagamento);
            }
        }
    }
}