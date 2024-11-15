/*
 * Implementazione di Grafi Diretti e Non Diretti usando la programmazione ad oggetti
 * Progetto di Antonio De Rosa 4H 2024-11-15
 */ 
namespace DijkstraOOP
{
    public class GrafoDiretto
    {
        public struct Arco
        {
            public int nodo_partenza;
            public int nodo_arrivo;
            public int costo;
        }

        private int numeroNodi;
        private int numeroMaxNodi;
        private List<string> nodi;
        private List<Arco> archi;

        /// <summary>
        /// Costruisce la classe, è garantito che non si supererà numero_max_nodi.
        /// </summary>
        /// <param name="numero_max_nodi">Numero massimo di nodi.</param>
        public GrafoDiretto(int numero_max_nodi = 1000)
        {
            this.numeroMaxNodi = numero_max_nodi;
            this.nodi = new List<string>(numeroMaxNodi);
            this.archi = new List<Arco>();
        }

        /// <summary>
        /// Proprietà che torna il numero attuale di nodi inseriti.
        /// </summary>
        public int NumeroNodi { get { return nodi.Count; } }

        /// <summary>
        /// Aggiunge un nodo.
        /// </summary>
        /// <param name="nome">Nome del nodo.</param>
        public void AggiungiNodo(string nome)
        {
            if (nodi.Count >= numeroMaxNodi) throw new Exception($"You cannot add more than {numeroMaxNodi} nodes.");
            nodi.Add(nome);
        }

        /// <summary>
        /// Aggiunge un arco fra i due nodi dati, con il costo indicato.
        /// </summary>
        /// <param name="nome_nodo_partenza">Nome del nodo di partenza.</param>
        /// <param name="nome_nodo_arrivo">Nome del nodo di arrivo.</param>
        /// <param name="costo">Costo dell'arco.</param>
        public virtual void AggiungiArco(string nome_nodo_partenza, string nome_nodo_arrivo, int costo)
        {
            Arco arco;
            arco.costo = costo;
            int idxPartenza = this[nome_nodo_partenza];
            int idxArrivo = this[nome_nodo_arrivo];
            if (idxPartenza == -1 || idxArrivo == -1) throw new IndexOutOfRangeException("L'indice di partenza o di arrivo non è valido.");
            arco.nodo_partenza = idxPartenza;
            arco.nodo_arrivo = idxArrivo;

            archi.Add(arco);
        }

        /// <summary>
        /// Aggiunge un arco fra i due nodi dati, con il costo indicato.
        /// </summary>
        /// <param name="arco">Struttura dell'arco da aggiungere.</param>
        public virtual void AggiungiArco(Arco arco)
        {
            archi.Add(arco);
        }

        /// <summary>
        /// Indicizzatore per i nodi.
        /// </summary>
        /// <param name="nodo">Indice del nodo.</param>
        /// <returns>Nome del nodo.</returns>
        public string this[int nodo]
        {
            get { return nodi[nodo]; }
        }

        /// <summary>
        /// Indicizzatore per i nodi.
        /// </summary>
        /// <param name="nome_nodo">Nome del nodo.</param>
        /// <returns>Indice del nodo.</returns>
        public int this[string nome_nodo]
        {
            get
            {
                for (int i = 0; i < nodi.Count; i++)
                {
                    if (nodi[i] == nome_nodo) return i;
                }

                throw new IndexOutOfRangeException();
            }
        }

        /// <summary>
        /// Enumeratore per gli archi uscenti dal nodo dato.
        /// </summary>
        /// <param name="nodo">Indice del nodo.</param>
        /// <returns>Archi uscenti dal nodo.</returns>
        public IEnumerable<Arco> ArchiUscenti(int nodo)
        {
            foreach (var arco in archi)
            {
                if (arco.nodo_partenza == nodo)
                {
                    yield return arco;
                }
            }
        }

        /// <summary>
        /// Enumeratore per gli archi entranti nel nodo dato.
        /// </summary>
        /// <param name="nodo">Indice del nodo.</param>
        /// <returns>Archi entranti nel nodo.</returns>
        public IEnumerable<Arco> ArchiEntranti(int nodo)
        {
            foreach (var arco in archi)
            {
                if (arco.nodo_arrivo == nodo)
                {
                    yield return arco;
                }
            }
        }

        /// <summary>
        /// Controlla se l'indice del nodo è valido.
        /// </summary>
        /// <param name="nodo">Indice del nodo.</param>
        /// <returns>True se l'indice è valido, altrimenti false.</returns>
        public bool ControllaIndiceNodo(int nodo)
        {
            try
            {
                string BinObj = nodi[nodo];
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }

    public class GrafoNonDiretto : GrafoDiretto  // specializzazione di GrafoDiretto per grafi "non diretti" (se si può andare da A a B con costo 10, allora si va anche da B ad A con lo stesso costo)
    {
        /// <summary>
        /// Costruisce la classe, è garantito che non si supererà numero_max_nodi.
        /// </summary>
        /// <param name="numero_max_nodi">Numero massimo di nodi.</param>
        public GrafoNonDiretto(int numero_max_nodi = 1000) : base(numero_max_nodi) { }

        /// <summary>
        /// Aggiunge un arco fra i due nodi dati, con il costo indicato.
        /// </summary>
        /// <param name="nome_nodo_partenza">Nome del nodo di partenza.</param>
        /// <param name="nome_nodo_arrivo">Nome del nodo di arrivo.</param>
        /// <param name="costo">Costo dell'arco.</param>
        public override void AggiungiArco(string nome_nodo_partenza, string nome_nodo_arrivo, int costo)
        {
            base.AggiungiArco(nome_nodo_partenza, nome_nodo_arrivo, costo);
            base.AggiungiArco(nome_nodo_arrivo, nome_nodo_partenza, costo);
        }

        /// <summary>
        /// Aggiunge un arco fra i due nodi dati, con il costo indicato.
        /// </summary>
        /// <param name="arco">Struttura dell'arco da aggiungere.</param>
        public override void AggiungiArco(Arco arco)
        {
            base.AggiungiArco(arco);

            // Creo il secondo arco.
            int idxTemp = arco.nodo_partenza;
            arco.nodo_partenza = arco.nodo_arrivo;
            arco.nodo_arrivo = idxTemp;

            base.AggiungiArco(arco);
        }
    }
}
