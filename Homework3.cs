namespace School;

// Домашнее задание 3: оценка сложности (O, Ω, Θ).
// На занятии разбирали другие примеры в проекте ComplexityExamples; здесь — новые фрагменты.
// O - оценка наихудшего случая
// Ω - оценка лучшего случая
// Θ - точная оценка (возможна только, если O = Ω)

public static class Homework3Assignment
{
    /*
     * Готовый код ниже — только анализ, сами методы не меняйте.
     *
     * Укажите O, Ω и Θ по времени от n, где n = arr.Length.
     */
    public static int FixedLoopXor(int[] arr)
    {
        var acc = 0;
        for (var k = 0; k < 4096; k++)
            acc ^= k;
        return acc;
    }

    /*
     * Готовый код — только анализ, метод не меняйте.
     *
     * Укажите O, Ω и Θ по времени от n = items.Length. Дополнительно оцените дополнительную
     * память (память на хранение входного массива не учитывается, учитывается только дополнительная память).
     */
    public static void ReverseInPlace(int[] items)
    {
        if (items is null || items.Length <= 1)
            return;
        var left = 0;
        var right = items.Length - 1;
        while (left < right)
        {
            (items[left], items[right]) = (items[right], items[left]);
            left++;
            right--;
        }
    }

    /*
     * Готовый код — только анализ, метод не меняйте.
     *
     * Укажите O, Ω и Θ по времени от n = items.Length.
     */
    public static int CountOccurrences(int[] items, int value)
    {
        if (items is null || items.Length == 0)
            return 0;
        var count = 0;
        for (var i = 0; i < items.Length; i++)
        {
            if (items[i] == value)
                count++;
        }

        return count;
    }

    /*
     * Готовый код — только анализ, метод не меняйте.
     *
     * Укажите O, Ω и Θ по времени от n = items.Length. Ответьте коротко: есть ли Θ
     */
    public static bool HasEvenNumber(int[] items)
    {
        if (items is null)
            return false;
        for (var i = 0; i < items.Length; i++)
        {
            if ((items[i] & 1) == 0)
                return true;
        }

        return false;
    }

    /*
     * Готовый код — только анализ, метод не меняйте.
     *
     * Пусть n = matrix.GetLength(0) и матрица квадратная n×n. Укажите O, Ω и Θ по времени
     * от n и оценку дополнительной памяти.
     */
    public static long SumMatrix(int[,] matrix)
    {
        var rows = matrix.GetLength(0);
        var cols = matrix.GetLength(1);
        long sum = 0;
        for (var i = 0; i < rows; i++)
        {
            for (var j = 0; j < cols; j++)
                sum += matrix[i, j];
        }

        return sum;
    }

    /*
     * Пары с заданной суммой (реализуйте вместо заглушки).
     *
     * Дан массив длины n и целое target. Нужно посчитать количество пар индексов (i, j),
     * таких что i меньше j и array[i] + array[j] равно target.
     *
     * Ограничения: время O(n²), дополнительная память O(1) — наивный двойной цикл по индексам.
     */
    public static int CountPairsWithTargetSumSlow(int[] array, int target) =>
        throw new NotImplementedException(
            "Два вложенных цикла: все пары индексов с i меньше j, проверка суммы.");
    // [2, 3, 4, 6, 1, 45, 6]
    // 7
    // 3
    // [2, 3, 4, 6, 1, 45, 6]
    // [   3, 4, 6, 1, 45, 6]
    // [      4, 6, 1, 45, 6]
    // [         6, 1, 45, 6]
    // [            1, 45, 6]

    /*
     * Та же задача, другие ограничения: время O(n), дополнительная память O(n).
     * Без сортировок и без рекурсии.
     *
     * Идея: один проход слева направо, храните частоты уже просмотренных значений; на каждом
     * шаге добавляйте к ответу число подходящих индексов слева с нужной суммой (через target
     * и текущий элемент).
     */
    public static int CountPairsWithTargetSumFast(int[] array, int target) =>
        throw new NotImplementedException("Например, Dictionary<int, int> для частот.");
    
    // [2, 3, 4, 6, 6, 1, 45, 6, 1, 3]
    // 7
    // 8
    // [2]: 1
    // [3]: 2
    // [4]: 1
    // [6]: 3
    // [1]: 2
    // [45]: 1
    

    /*
     * Палиндром (реализуйте вместо заглушки).
     *
     * Нужно проверить, читается ли строка одинаково слева направо и справа налево.
     * Параметр ignoreCase: если true, буквы сравнивайте без учёта регистра; 
     *
     * Ограничения: время O(n), дополнительная память O(n) — допускается, например, обращённая
     * копия в массиве символов или новой строке и сравнение с исходной.
     */
    public static bool IsPalindromeWithReversedCopy(string text, bool ignoreCase) =>
        throw new NotImplementedException();
    
    // abcba
    // тонетенот
    // Array.Reverse(copy)
    // string.Compare(text, reverseCopy)

    /*
     * Та же проверка палиндрома, другие ограничения: время O(n), дополнительная память O(1).
     *
     * Идея: два индекса с краёв строки, движение к центру, попарное сравнение с учётом
     * ignoreCase, без копии длины n.
     */
    public static bool IsPalindromeTwoPointers(string text, bool ignoreCase) =>
        throw new NotImplementedException();

    // тонетенот
    // L       R
    //  L     R
    //   L   R
    //    L R
    //     
     
    /*
     * Требования к результату
     *
     * После выполнения задания:
     * — по готовым методам выше: в комментариях к каждому методу укажите O, Ω и Θ по времени и памяти, если требуется;
     * — CountPairsWithTargetSumSlow / Fast: рабочий код и в комментариях укажите O, Ω и Θ по времени и памяти;
     * — IsPalindromeWithReversedCopy / IsPalindromeTwoPointers: рабочий код и в комментариях укажите O, Ω и Θ по времени и памяти;
     * — в решениях по парам и палиндрому не используйте рекурсию и сортировки как способ уложиться в сложность.
     *
     * Вопросы для самопроверки (присылать не нужно)
     *
     * В чём разница между O и Ω? Когда уместно говорить про Θ? Почему копия строки обычно
     * даёт O(n) дополнительной памяти, а два указателя по краям — O(1)?
     */
}
