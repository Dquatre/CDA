int nbPognon = 1000;
List<int> carteCroupier = new List<int>();
List<int> carteJoueur = new List<int>();
List<int> carteDisponible = new List<int> { 1, 1, 1, 1, 2, 2, 2, 2, 3, 3, 3, 3, 4, 4, 4, 4, 5, 5, 5, 5, 6, 6, 6, 6, 7, 7, 7, 7, 8, 8, 8, 8, 9, 9, 9, 9, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };


/*
 * Affiche le pognon
 */
static void start()
{

}

/**
 * Mise du joueur
 * 
 * param int nbPognon total du pognon du joueur
 * 
 * return int mise du joueur
 */
static int bet(ref int nbPognon)
{
    int mise;
    do
    {
        Console.WriteLine("combien voulez vous miser ? ");
    } while (!int.TryParse(Console.ReadLine(), out mise) || mise < 0 && mise > nbPognon);
    nbPognon -= mise;
    return mise;
}

/**
 * Distrubution des cartes
 * 
 * param List<int> tabCarte tableau avec les cartes disponible
 * 
 * return int valeur de la carte
 */
static int distribut(List<int> tabCarte)
{
    Random rnd = new Random();
    int card = rnd.Next(tabCarte.Count());
    int valCard = tabCarte[card];
    tabCarte.RemoveAt(card);
    return valCard;
}

/**
 * Affiche la mise, la carte du croupier, les cartes du joueur et le pognon disponible 
 * 
 * param int mise mise du joueur
 * param List<int> carteCroupier carte piocher par le croupier
 * param List<int> carteJoueur carte piocher par la joueur
 * param int pognonJoueur pognon du joueur
 */
static void display(int mise, List<int> carteCroupier, List<int> carteJoueur, int pognonJoueur)
{
    drawLine();

    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("Jetons : " + pognonJoueur + " | " + "Mise : " + mise);
    Console.ForegroundColor = ConsoleColor.White;
    for (int i = 0; i < 100; i++)
    {
        Console.Write('-');
    }

    Console.Write("\n\n");

    switch (carteJoueur.Sum())
    {
        case 21:
            Console.ForegroundColor = ConsoleColor.Green;
            break;
        case > 21:
            Console.ForegroundColor = ConsoleColor.Red;
            break;
        default:
            break;
    }

    Console.Write("Vos cartes : ");

    for (int i = 0; i < carteJoueur.Count; i++)
    {
        Console.Write(carteJoueur[i]);
        if (i < carteJoueur.Count - 1)
        {
            Console.Write(", ");
        }
    }

    Console.Write(" | Total = " + carteJoueur.Sum());

    Console.Write("\n\n");

    switch (carteCroupier.Sum())
    {
        case 21:
            Console.ForegroundColor = ConsoleColor.Green;
            break;
        case > 21:
            Console.ForegroundColor = ConsoleColor.Red;
            break;
        default:
            Console.ForegroundColor = ConsoleColor.White;
            break;
    }

    Console.Write("Cartes du croupier : ");

    for (int i = 0; i < carteCroupier.Count; i++)
    {
        Console.Write(carteCroupier[i]);
        if (i < carteCroupier.Count - 1)
        {
            Console.Write(", ");
        }
    }

    Console.Write(" | Total = " + carteCroupier.Sum());

    Console.ForegroundColor = ConsoleColor.White;

    Console.Write("\n\n");

    drawLine();

    if (carteJoueur.Sum() == 21 || carteCroupier.Sum() > 21)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Vous avez gagn� !");
    }
    else if (carteJoueur.Sum() > 21 || carteCroupier.Sum() == 21)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Vous avez perdu !");
    }
    else
    {
        Console.WriteLine("Tirez une carte ou restez");
    }

    Console.ForegroundColor = ConsoleColor.White;

    drawLine();
}

static void drawLine()
{
    for (int i = 0; i < 100; i++)
    {
        Console.Write('-');
    }
    Console.Write("\n");
}




/**
 * Tour du joueur, met a jour la list des cartes du joueur
 * 
 * param List<int>carteJoueur liste des cartes du joueur
 * 
 * return List<int> liste des cartes du joueur 
 */
static Double playerTurn(List<int> carteJoueur, List<int> tabCarte, Double Mise)
{
    int choixJoueur;
    do
    {
        Console.WriteLine("\n0- stopper\n1- tirer des cartes\n2- Doubler sa miser et tirer une carte");
        Console.Write("Choix : ");
    } while (!int.TryParse(Console.ReadLine(), out choixJoueur) || choixJoueur < 0 || choixJoueur > 2);

    switch (choixJoueur)
    {
        case 0:
            break;
        case 1:
            carteJoueur.Add(distribut(tabCarte));
            break;
        case 2:
            carteJoueur.Add(distribut(tabCarte));
            Mise *= 2.0;
            break;

    }
    return Mise;
}

/**
 * Permet l'état de la partie: si le joueur n'a pas plus de 21, si il a 21, si il a plus ou moins que la banque
 * 
 * param int tour 
 * 
 * return int 
 */
static int check(int tour)
{

}

/**
 * Tirage des cartes du croupier et met à jour les cartes du croupier
 * 
 * param List<int> carteCroupier Liste des cartes du croupier
 * param List<int> carteJoueur Liste des cartes du joueur
 * 
 * return List<int> 
 */
static List<int> bankTurn(List<int> carteCroupier, List<int> carteJoueur, List<int> carteDisponible)
{
    while (carteCroupier.Sum() < carteJoueur.Sum() || carteCroupier.Sum() == 21)
    {
        Random random = new Random();
        int chiffre = random.Next(carteDisponible.Count());
        int carteSelectionner = carteDisponible[chiffre];

        if (carteSelectionner == 1 && carteCroupier.Sum() > 10)
        {
            carteCroupier.Add(1);
        }
        else if (carteSelectionner == 1 && carteCroupier.Sum() < 10)
        {
            carteCroupier.Add(11);
        }
        else
        {
            carteCroupier.Add(carteSelectionner);
        }

    }

    return carteCroupier;
}


/**
 * Check la win du joueur
 * 
 * param List<int> carteCroupier Liste des cartes du croupier
 * param List<int> carteJoueur Liste des cartes du joueur
 */
static void endTurn(List<int> cartesCroupier, List<int> cartesJoueur)
{
    if (cartesCroupier.Contains(1) && cartesCroupier.Sum() >21)
    {
        
    }
}

