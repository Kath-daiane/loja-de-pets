using System;

class Programa
{
    class Animal
    {
        public string Nome;
        public string Especie;
        public decimal Preco;

        public void ExibirInformacoes()
        {
            Console.WriteLine($"Nome: {Nome}, Espécie: {Especie}, Preço: R${Preco}");
        }
    }

    class Cliente
    {
        public string Nome;
        public string Telefone;

        public void ExibirInformacoes()
        {
            Console.WriteLine($"Nome: {Nome}, Telefone: {Telefone}");
        }
    }

    class Venda
    {
        public Animal Animal;
        public Cliente Cliente;
        public DateTime DataVenda;

        public void ExibirInformacoes()
        {
            Console.WriteLine($"Animal: {Animal.Nome}, Cliente: {Cliente.Nome}, Data: {DataVenda.ToShortDateString()}");
        }
    }

    class Loja
    {
        public Animal[] animais = new Animal[3];
        public Cliente[] clientes = new Cliente[3];
        public Venda[] vendas = new Venda[3];
        public int animalCount = 0;
        public int clienteCount = 0;
        public int vendaCount = 0;

        public void CadastrarAnimal()
        {
            Animal animal = new Animal();
            Console.Write("Nome do animal: ");
            animal.Nome = Console.ReadLine();
            Console.Write("Espécie do animal: ");
            animal.Especie = Console.ReadLine();
            Console.Write("Preço do animal: ");
            animal.Preco = Convert.ToDecimal(Console.ReadLine());

            animais[animalCount++] = animal;
            Console.WriteLine("Animal cadastrado com sucesso!");
        }

        public void CadastrarCliente()
        {
            Cliente cliente = new Cliente();
            Console.Write("Nome do cliente: ");
            cliente.Nome = Console.ReadLine();
            Console.Write("Telefone do cliente: ");
            cliente.Telefone = Console.ReadLine();

            clientes[clienteCount++] = cliente;
            Console.WriteLine("Cliente cadastrado com sucesso!");
        }

        public void RegistrarVenda()
        {
            Venda venda = new Venda();
            Console.WriteLine("Escolha um animal para a venda:");
            for (int i = 0; i < animalCount; i++)
            {
                Console.WriteLine($"{i + 1} - {animais[i].Nome}");
            }
            Console.Write("Escolha o número do animal: ");
            int animalEscolhido = Convert.ToInt32(Console.ReadLine()) - 1;

            Console.WriteLine("Escolha um cliente:");
            for (int i = 0; i < clienteCount; i++)
            {
                Console.WriteLine($"{i + 1} - {clientes[i].Nome}");
            }
            Console.Write("Escolha o número do cliente: ");
            int clienteEscolhido = Convert.ToInt32(Console.ReadLine()) - 1;

            venda.Animal = animais[animalEscolhido];
            venda.Cliente = clientes[clienteEscolhido];
            venda.DataVenda = DateTime.Now;

            vendas[vendaCount++] = venda;
            Console.WriteLine("Venda registrada com sucesso!");
        }

        public void ExibirAnimais()
        {
            Console.WriteLine("Animais Disponíveis:");
            for (int i = 0; i < animalCount; i++)
            {
                animais[i].ExibirInformacoes();
            }
        }

        public void ExibirClientes()
        {
            Console.WriteLine("Clientes Cadastrados:");
            for (int i = 0; i < clienteCount; i++)
            {
                clientes[i].ExibirInformacoes();
            }
        }

        public void ExibirVendas()
        {
            Console.WriteLine("Vendas Registradas:");
            for (int i = 0; i < vendaCount; i++)
            {
                vendas[i].ExibirInformacoes();
            }
        }
    }

    static void Main()
    {
        Loja loja = new Loja();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Sistema de Loja de Animais");
            Console.WriteLine("1 - Cadastrar Animal");
            Console.WriteLine("2 - Cadastrar Cliente");
            Console.WriteLine("3 - Registrar Venda");
            Console.WriteLine("4 - Exibir Animais");
            Console.WriteLine("5 - Exibir Clientes");
            Console.WriteLine("6 - Exibir Vendas");
            Console.WriteLine("7 - Sair");
            Console.Write("Escolha uma opção: ");
            int opcao = Convert.ToInt32(Console.ReadLine());

            if (opcao == 1) loja.CadastrarAnimal();
            if (opcao == 2) loja.CadastrarCliente();
            if (opcao == 3) loja.RegistrarVenda();
            if (opcao == 4) loja.ExibirAnimais();
            if (opcao == 5) loja.ExibirClientes();
            if (opcao == 6) loja.ExibirVendas();
            if (opcao == 7) break;

            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
        }

        Console.WriteLine("Sistema encerrado.");
    }
}
