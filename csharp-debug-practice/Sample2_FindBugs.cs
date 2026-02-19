// Sample2: バグ探し練習
// 目的: デバッグ実行でバグの原因を特定し、修正する
//
// ⚠️ このコードには意図的にバグが含まれています！
// デバッグ実行で原因を見つけて修正してください。

using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Sample2: バグ探し練習 ===");
        Console.WriteLine("各問題を実行してバグを見つけてください！");
        Console.WriteLine();

        // 問題を選択
        Console.WriteLine("実行したい問題を選んでください:");
        Console.WriteLine("1. 配列の範囲外アクセス");
        Console.WriteLine("2. ループの無限ループ");
        Console.WriteLine("3. 計算ミス");
        Console.WriteLine("4. Null参照エラー");
        Console.WriteLine("5. 型変換エラー");
        Console.Write("選択 (1-5): ");

        string input = Console.ReadLine();
        int choice = int.Parse(input);

        switch (choice)
        {
            case 1:
                Problem1_ArrayOutOfBounds();
                break;
            case 2:
                Problem2_InfiniteLoop();
                break;
            case 3:
                Problem3_CalculationError();
                break;
            case 4:
                Problem4_NullReference();
                break;
            case 5:
                Problem5_TypeConversion();
                break;
            default:
                Console.WriteLine("1-5を選択してください");
                break;
        }

        Console.WriteLine();
        Console.WriteLine("デバッグ完了！");
        Console.ReadKey();
    }

    // 問題1: 配列の範囲外アクセス
    // 【バグ】配列のインデックスが範囲外
    // 【修正方法】ブレークポイントで i の値を確認して修正
    static void Problem1_ArrayOutOfBounds()
    {
        Console.WriteLine("\n--- 問題1: 配列の範囲外アクセス ---");
        int[] scores = { 85, 90, 78, 92, 88 };

        Console.WriteLine("成績一覧:");
        for (int i = 0; i <= scores.Length; i++)  // ← バグ: i <= は範囲外
        {
            Console.WriteLine($"生徒{i + 1}: {scores[i]}点");
        }

        // 【ヒント】
        // 1. 64行目にブレークポイント
        // 2. ウォッチに i と scores.Length を登録
        // 3. F10 でステップ実行して i の値を確認
        // 4. i がどこでエラーになるか特定
    }

    // 問題2: ループの無限ループ
    // 【バグ】カウンタが減ってしまう
    // 【修正方法】ブレークポイントで count の変化を追跡
    static void Problem2_InfiniteLoop()
    {
        Console.WriteLine("\n--- 問題2: ループの無限ループ ---");
        Console.WriteLine("10から1までカウントダウン:");

        int count = 10;
        while (count > 0)
        {
            Console.WriteLine(count);
            count--;  // ← 一見正しそうだが...
            count++;  // ← バグ: 増減が相殺されて無限ループ
        }

        // 【ヒント】
        // 1. 91行目にブレークポイント
        // 2. ウォッチに count を登録
        // 3. F10 を数回押して count の値を観察
        // 4. count が減っていない原因を特定

        // ⚠️ 無限ループを止めるには: Shift+F5 でデバッグ停止
    }

    // 問題3: 計算ミス
    // 【バグ】平均値の計算が間違っている
    // 【修正方法】計算式を確認
    static void Problem3_CalculationError()
    {
        Console.WriteLine("\n--- 問題3: 計算ミス ---");
        int[] values = { 10, 20, 30, 40, 50 };

        int sum = 0;
        for (int i = 0; i < values.Length; i++)
        {
            sum += values[i];
        }

        int average = sum / 2;  // ← バグ: 2 で割っている（正しくは values.Length）

        Console.WriteLine($"合計: {sum}");
        Console.WriteLine($"平均: {average}");  // 期待値: 30 だが...

        // 【ヒント】
        // 1. 120行目にブレークポイント
        // 2. sum と values.Length の値を確認
        // 3. average の計算式が正しいか検証
    }

    // 問題4: Null参照エラー
    // 【バグ】null の文字列を使おうとしている
    // 【修正方法】null チェックを追加
    static void Problem4_NullReference()
    {
        Console.WriteLine("\n--- 問題4: Null参照エラー ---");

        string name = GetUserName();
        int length = name.Length;  // ← バグ: name が null の可能性

        Console.WriteLine($"名前: {name}, 文字数: {length}");

        // 【ヒント】
        // 1. 144行目にブレークポイント
        // 2. ローカルウィンドウで name の値を確認
        // 3. null の場合の処理を追加

        // 【修正例】
        // if (name != null) { ... }
        // または name?.Length ?? 0
    }

    static string GetUserName()
    {
        // ランダムでnullを返す
        Random rand = new Random();
        return rand.Next(2) == 0 ? null : "Taro";
    }

    // 問題5: 型変換エラー
    // 【バグ】数値でない文字列を変換しようとしている
    // 【修正方法】TryParse を使う
    static void Problem5_TypeConversion()
    {
        Console.WriteLine("\n--- 問題5: 型変換エラー ---");

        Console.Write("数値を入力してください: ");
        string input = Console.ReadLine();

        int number = int.Parse(input);  // ← バグ: 数値以外でエラー
        int doubled = number * 2;

        Console.WriteLine($"入力値: {number}, 2倍: {doubled}");

        // 【ヒント】
        // 1. 180行目にブレークポイント
        // 2. input の値を確認
        // 3. "abc" などを入力するとエラーになる

        // 【修正例】
        // if (int.TryParse(input, out int number)) { ... }
    }
}

/*
【バグ一覧と答え】

問題1: 配列の範囲外アクセス
❌ for (int i = 0; i <= scores.Length; i++)
✅ for (int i = 0; i < scores.Length; i++)
   → <= を < に変更

問題2: ループの無限ループ
❌ count--; count++;
✅ count--; のみ
   → 余計な count++; を削除

問題3: 計算ミス
❌ int average = sum / 2;
✅ int average = sum / values.Length;
   → 2 ではなく配列の長さで割る

問題4: Null参照エラー
❌ int length = name.Length;
✅ int length = name?.Length ?? 0;
   または if (name != null) でチェック

問題5: 型変換エラー
❌ int number = int.Parse(input);
✅ if (int.TryParse(input, out int number)) { ... }
   → TryParse でエラーハンドリング

【確認ポイント】
✓ ブレークポイントでバグの箇所を特定できた
✓ ローカルウィンドウで変数の値を確認できた
✓ ウォッチで重要な変数を追跡できた
✓ バグの原因を理解して修正できた

次のステップ: Sample3_Advanced.cs で応用練習！
*/
