// Sample3: 応用練習（条件付きブレークポイント、ウォッチ式）
// 目的: より高度なデバッグ機能を習得

using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Sample3: 応用練習 ===");
        Console.WriteLine();

        // 練習1: 条件付きブレークポイント
        ConditionalBreakpointPractice();

        Console.WriteLine();

        // 練習2: 複雑なオブジェクトのデバッグ
        ObjectDebuggingPractice();

        Console.WriteLine();

        // 練習3: コールスタックの確認
        CallStackPractice();

        Console.WriteLine();
        Console.WriteLine("応用練習完了！");
        Console.ReadKey();
    }

    // 練習1: 条件付きブレークポイント
    // 【やること】
    // 1. 39行目にブレークポイントを設定
    // 2. ブレークポイントを右クリック → 条件
    // 3. 「i == 50」と入力
    // 4. F5 で実行 → i が 50 の時だけ停止する！
    static void ConditionalBreakpointPractice()
    {
        Console.WriteLine("--- 条件付きブレークポイント ---");
        Console.WriteLine("1から100までの合計を計算");

        int sum = 0;
        for (int i = 1; i <= 100; i++)
        {
            sum += i;  // ← ここに条件付きブレークポイント: i == 50

            if (i % 10 == 0)  // 10の倍数だけ表示
            {
                Console.WriteLine($"i={i}, sum={sum}");
            }
        }

        Console.WriteLine($"最終合計: {sum}");

        // 【応用】
        // ・i >= 90 で条件を変更してみる
        // ・sum > 1000 で試してみる
        // ・ヒットカウント（5回目のループで停止）も試す
    }

    // 練習2: 複雑なオブジェクトのデバッグ
    // 【やること】
    // 1. 69行目にブレークポイントを設定
    // 2. ローカルウィンドウで students を展開
    // 3. 各学生の Name, Age, Score を確認
    // 4. student にマウスオーバーでプロパティを確認
    static void ObjectDebuggingPractice()
    {
        Console.WriteLine("--- オブジェクトのデバッグ ---");

        List<Student> students = new List<Student>
        {
            new Student("太郎", 20, 85),
            new Student("花子", 19, 92),
            new Student("次郎", 21, 78),
            new Student("美咲", 20, 95)
        };

        foreach (var student in students)
        {
            string result = student.GetResult();  // ← ブレークポイント
            Console.WriteLine($"{student.Name}さん ({student.Age}歳): {student.Score}点 - {result}");
        }

        // 【確認ポイント】
        // ・ローカルウィンドウで students を展開
        // ・student の各プロパティを確認
        // ・ウォッチに student.Score を登録して追跡
        // ・GetResult() の中にF11でステップイン
    }

    // 練習3: コールスタックの確認
    // 【やること】
    // 1. 96行目にブレークポイントを設定
    // 2. F5 で実行して停止
    // 3. 「呼び出し履歴」ウィンドウを確認
    // 4. Main → CallStackPractice → MethodA → MethodB → MethodC の流れを確認
    static void CallStackPractice()
    {
        Console.WriteLine("--- コールスタックの確認 ---");
        MethodA(10);
    }

    static void MethodA(int value)
    {
        Console.WriteLine("MethodA 実行中");
        MethodB(value * 2);
    }

    static void MethodB(int value)
    {
        Console.WriteLine("MethodB 実行中");
        MethodC(value + 5);
    }

    static void MethodC(int value)
    {
        Console.WriteLine("MethodC 実行中");
        int result = value * value;  // ← ブレークポイント
        Console.WriteLine($"計算結果: {result}");

        // 【確認ポイント】
        // ・呼び出し履歴ウィンドウで MethodC → MethodB → MethodA → Main の順を確認
        // ・各メソッドをダブルクリックすると該当行にジャンプ
        // ・どこから呼ばれたか遡れる
    }
}

// 学生クラス
class Student
{
    public string Name { get; set; }
    public int Age { get; set; }
    public int Score { get; set; }

    public Student(string name, int age, int score)
    {
        Name = name;
        Age = age;
        Score = score;
    }

    public string GetResult()
    {
        if (Score >= 90)
            return "優秀";
        else if (Score >= 80)
            return "良好";
        else if (Score >= 70)
            return "普通";
        else
            return "要努力";
    }
}

/*
【高度なデバッグテクニック】

1. 条件付きブレークポイント
   - 特定の条件でのみ停止
   - 大量のループで特定の値だけチェックしたい時に便利

2. ヒットカウント
   - 「○回目のループで停止」など
   - ブレークポイント右クリック → ヒット カウント

3. データヒント（ピン留め）
   - 変数にマウスオーバー → 📌アイコンで固定
   - デバッグ中常に表示される

4. ウォッチ式
   - student.Score * 2 のような式も監視できる
   - students.Count などのプロパティも追跡

5. イミディエイトウィンドウ
   - デバッグ中にコードを実行
   - 変数の値を変更してテスト
   - 例: score = 100 で変数を書き換え

6. 呼び出し履歴（コールスタック）
   - 現在の関数がどこから呼ばれたか確認
   - エラーの原因を遡って特定

【実務での活用例】

✓ 大量データ処理で特定IDだけデバッグ
  → 条件付きブレークポイント: id == "ABC123"

✓ ループの途中から確認したい
  → ヒットカウント: 100回目から

✓ 複雑なオブジェクトの中身確認
  → ローカルウィンドウで展開、ウォッチで追跡

✓ エラーの原因を遡る
  → コールスタックで呼び出し元を特定

【確認ポイント】
✓ 条件付きブレークポイントを設定できた
✓ ヒットカウントを使えた
✓ 複雑なオブジェクトをデバッグできた
✓ コールスタックで呼び出し履歴を確認できた
✓ ウォッチ式で計算式を追跡できた

これでデバッグ実行の基本は完璧！
実務でどんどん使ってスキルアップしよう！
*/
