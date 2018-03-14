using System;
class Odd{
private static char[] characters =
    new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J' };

// length: The length of the string created by bruteforce
public static void PerformBruteForce(int length) {
    int charactersLength = characters.Length;
    int[] odometer = new int[length];
    long size = (long)Math.Pow(charactersLength, length);

    for (int i = 0; i < size; i++) {
        WriteBruteForce(odometer, characters);
        int position = 0;
        do {
            odometer[position] += 1;
            odometer[position] %= charactersLength;
        } while (odometer[position++] == 0 && position < length);
    }
}

private static void WriteBruteForce(int[] odometer, char[] characters) {
    // Print backwards
    for (int i = odometer.Length - 1; i >= 0; i--) {
        Console.Write(characters[odometer[i]]);
    }
    Console.WriteLine();
}
public static void Main(String [] args)
{
	PerformBruteForce(3);
}
}
