// Sample1: 基本的なデバッグ練習
// 目的: ブレークポイント、ステップ実行、変数確認の基本を習得

using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Sample1: 基本的なデバッグ練習 ===");
        Console.WriteLine();

        // 練習1: 単純な変数の追跡
        // 【やること】
        // 1. 13行目にブレークポイントを設定
        // 2. F5 でデバッグ実行
        // 3. F10 で一行ずつ進めながら、ローカルウィンドウで変数を確認
        int a = 10;
        int b = 20;
        int sum = a + b;
        Console.WriteLine($"a={a}, b={b}, sum={sum}");
        Console.WriteLine();

        // 練習2: ループ内の変数を追跡
        // 【やること】
        // 1. 24行目にブレークポイントを設定
        // 2. F5 で実行
        // 3. ローカルウィンドウで i と total の変化を観察
        // 4. F10 を何度か押してループの動作を確認
        Console.WriteLine("--- ループ内の変数追跡 ---");
        int total = 0;
        for (int i = 1; i <= 5; i++)
        {
            total += i;  // ← ここにブレークポイント
            Console.WriteLine($"i={i}, total={total}");
        }
        Console.WriteLine($"最終合計: {total}");
        Console.WriteLine();

        // 練習3: 関数呼び出しとステップイン
        // 【やること】
        // 1. 39行目にブレークポイントを設定
        // 2. F11 (ステップイン) で関数の中に入る
        // 3. F10 で関数内を一行ずつ実行
        // 4. Shift+F11 (ステップアウト) で関数から抜ける
        Console.WriteLine("--- 関数呼び出しの追跡 ---");
        int x = 5;
        int y = 3;
        int result = Add(x, y);  // ← ここにブレークポイント、F11でステップイン
        Console.WriteLine($"{x} + {y} = {result}");
        Console.WriteLine();

        // 練習4: 配列の要素確認
        // 【やること】
        // 1. 52行目にブレークポイントを設定
        // 2. ローカルウィンドウで numbers を展開して各要素を確認
        // 3. numbers[i] にマウスオーバーで値を確認
        Console.WriteLine("--- 配列の要素確認 ---");
        int[] numbers = { 10, 20, 30, 40, 50 };
        for (int i = 0; i < numbers.Length; i++)
        {
            int doubled = numbers[i] * 2;  // ← ここにブレークポイント
            Console.WriteLine($"numbers[{i}] = {numbers[i]}, doubled = {doubled}");
        }
        Console.WriteLine();

        // 練習5: 条件分岐の追跡
        // 【やること】
        // 1. 64行目にブレークポイントを設定
        // 2. score の値を確認
        // 3. F10 でどの分岐に入るか確認
        Console.WriteLine("--- 条件分岐の追跡 ---");
        int score = 75;
        string grade = GetGrade(score);  // ← ここにブレークポイント、F11でステップイン
        Console.WriteLine($"Score: {score}, Grade: {grade}");

        Console.WriteLine();
        Console.WriteLine("デバッグ練習完了！");
        Console.ReadKey();
    }

    // 足し算関数
    static int Add(int a, int b)
    {
        int result = a + b;
        return result;  // ← ステップ実行でここまで追跡
    }

    // 成績判定関数
    static string GetGrade(int score)
    {
        if (score >= 90)
        {
            return "A";
        }
        else if (score >= 80)
        {
            return "B";
        }
        else if (score >= 70)
        {
            return "C";
        }
        else if (score >= 60)
        {
            return "D";
        }
        else
        {
            return "F";
        }
        // ← どの分岐を通ったか確認
    }
}

/*
【確認ポイント】
✓ ブレークポイントの設定・解除ができた
✓ F5 でデバッグ実行ができた
✓ F10 でステップオーバーができた
✓ F11 でステップインができた
✓ Shift+F11 でステップアウトができた
✓ ローカルウィンドウで変数の値を確認できた
✓ 変数にマウスオーバーで値を確認できた

次のステップ: Sample2_FindBugs.cs でバグ探しに挑戦！
*/
