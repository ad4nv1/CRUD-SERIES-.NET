using System;

namespace PrimeiroProjetoAvanade
{
    class Program
    {
         static SeriesRepositorio repositorio = new SeriesRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterInputsUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarSeries();
						break;
					case "2":
						InserirSerie();
						break;
					case "3":
						Atualizacao();
						break;
					case "4":
						ExcluirSerie();
						break;
					case "5":
						ExibirSerie();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterInputsUsuario();
			}

			Console.WriteLine("Obrigado pela confiança");
			Console.ReadLine();
        }

        private static void ExcluirSerie()
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			repositorio.Exclui(indiceSerie);
		}

        private static void ExibirSerie()
		{
			Console.Write("Digite o id desejado: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			var serieExibir = repositorio.RetornaIdDigitado(indiceSerie);

			Console.WriteLine(serieExibir);
		}

        private static void Atualizacao()
		{
			Console.Write("Digite o id da serie que será atualizada: ");
			int indiceSerie = int.Parse(Console.ReadLine());
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite uma opçao de genero: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite um título: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o ano de lançamento: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Crie uma descrição: ");
			string entradaDescricaoAtualizacao = Console.ReadLine();

			Series atualizacaoSerie = new Series(id: indiceSerie,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricaoAtualizacao);

			repositorio.Atualiza(indiceSerie, atualizacaoSerie);
		}
        private static void ListarSeries()
		{
			Console.WriteLine("Listar séries");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhuma série foi encontrada.");
				return;
			}

			foreach (var series in lista)
			{
                var excluido = series.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", series.retornaId(), series.retornaTitulo(), (excluido ? "Deletado" : ""));
			}
		}

        private static void InserirSerie()
		{
			Console.WriteLine("Inserir nova série");
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Série: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Série: ");
			string entradaDescricaoInsercao = Console.ReadLine();

			Series serieAdd = new Series(id: repositorio.ProximoId(),
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricaoInsercao);

			repositorio.Insere(serieAdd);
		}

        private static string ObterInputsUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("CRUD series!! Atvd");
			Console.WriteLine("escolha uma das opções:");

			Console.WriteLine("1) listar séries");
			Console.WriteLine("2) adicionar uma nova série");
			Console.WriteLine("3) atualizar série");
			Console.WriteLine("4) excluir uma série");
			Console.WriteLine("5) acessar série");
			Console.WriteLine("C) limpar Tela");
			Console.WriteLine("X) sair");
			Console.WriteLine();

			string inputUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return inputUsuario;
		}
    }
}

