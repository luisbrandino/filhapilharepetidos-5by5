using filapilha;

int size = 10;

void populateQueue(Queue queue)
{
    for (int i = 0; i < size; i++)
        queue.Enqueue(new Random().Next(-30, 30));
}

void populateStack(Stack stack)
{
    for (int i = 0; i < size; i++)
        stack.Push(new Random().Next(-30, 30));
}

int[]? getRepeatedValuesBetweenStructures(OperationalDataStructure structureA, OperationalDataStructure structureB)
{
    int[]? vector = structureB.ToVector();

    if (vector == null)
        return null;

    Queue repeated = new Queue();

    for (int i = 0; i < vector.Length; i++)
        if (structureA.Contains(vector[i]) && !repeated.Contains(vector[i]))
            repeated.Enqueue(vector[i]);

    return repeated.ToVector();
}

Queue queue = new Queue();
Stack stack =  new Stack();

populateQueue(queue);
populateStack(stack);

int[]? repeated = getRepeatedValuesBetweenStructures(queue, stack);

Console.WriteLine("FILA: \n");

queue.Display();

Console.WriteLine("\n\nPILHA: \n");

stack.Display();

Console.WriteLine("\n");

if (repeated == null)
{
    Console.WriteLine("Não há números repetidos entre as estruturas");
    Environment.Exit(0);
}

Console.WriteLine("Números repetidos entre as estruturas: \n");

for (int i = 0; i < repeated.Length; i++)
    Console.Write($"{repeated[i]} ");
