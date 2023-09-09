namespace FindDuplicates
{
    internal class Program
    {
        public bool ValidateArray(string array) {
            if (array == null)
                throw new ArgumentNullException();
            if (String.IsNullOrEmpty(array))
                throw new ArgumentNullException();
            else {
                Console.WriteLine("Validating the Array...");
                string[] split = array.Split(new[] { ' ', ',', ':', '|', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < split.Length; i++) {
                    if (!int.TryParse(split[i], out int result)) {
                        if (result < 1 || result > split.Length) {
                            return false;
                        }
                    }
                }
                return true;
            }
        }

        public static void Main(string[] args) {
            Console.WriteLine("Enter an array of integer values...");
            string array = Console.ReadLine();
            Program program = new Program();
            bool isValidArray = program.ValidateArray(array);
            if (isValidArray) {
                string[] split = array.Split(new[] { ' ', ',', ':', '|', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                int[] arrayOfNumbers = new int[split.Length];
                for (int i = 0; i < split.Length; i++) {
                    if (int.TryParse(split[i], out int result)) {
                        arrayOfNumbers[i] = result;
                    }
                }

                Dictionary<int, int> numsAndOccurrences = new Dictionary<int, int>();

                for (int i = 0; i < arrayOfNumbers.Length; i++) {
                    if (!numsAndOccurrences.ContainsKey(arrayOfNumbers[i])) {
                        numsAndOccurrences.Add(arrayOfNumbers[i], 1);
                    }
                    else {
                        numsAndOccurrences[arrayOfNumbers[i]]++;
                    }
                }

                foreach (KeyValuePair<int, int> pair in numsAndOccurrences) {
                    Console.WriteLine($"Number: {pair.Key}, Count: {pair.Value}");
                }
            }
        }
    }
}

