using System;

namespace DatentypenKontrollstrukturen
{
    class Datentypen
    {
        // Ganze Zahlen

        byte Ganzzahl8BitOhneVorzeichen; // 0 bis 255
        sbyte Ganzzahl8Bit; // -128  bis +127

        short Ganzzahl16Bit; // -/+ 32 Tausend
        ushort Ganzzahl16BitOhneVorzeichen; // 0 65535

        int Ganzzahl32Bit; // -2,14 Milliarden +2,14 Milliarden
        uint Ganzzahl32BitOhneVorzeichen; // 0 +4,29 Milliarden

        long Ganzzahl64Bit; // +/- 9 Trillionen?
        ulong Ganzzahl64BitOhneVorzeichen; // 0 bis 18 Trillionen?

        int MitBasis10Schreibweise = 6429;
        int MitBasis10UndTrenner = 6_429; // unterstrich dient nur der lesbarkeit und keine keine funktion
        int MitBasis2Befüllt = 0b_0001_1001_0001_1101; // binäre schreibweise, müssen immer 4er-blöcke sein
        int MitBasis16Befüllt = 0x191D;// hex schreibweise, immer 2er blöcke

        // Angenäherte Zahlen / Gebrochene Zahlen

        float Fliesskomma32Bit = 1.0f; // 5 bis 7 stellen genau
        double Flieskomma64Bit = 1.0d; // 13 Stellen genau
        decimal Fliesskomma128Bit; // braucht man fast nicht, VORSICHT SQL kennt das als Ganzzahl

        // Zeichen

        string Text = "Hallo"; // Text/Zeichenkette, 2Byte pro Zeichen, Anführungszeichen, interpretiert \n als Enter und auch weitere sonderzeichen
        // alternativen falls sonderzeichen oder fülltexte nötig sind
        string TextB = $"Meine Position {Environment.CurrentDirectory}"; // $ besagt das sowohl sonderzeichen wie \n interpretiert werden als auch fülltext mit geschweiften klammern
        string TextLiterally = @"keinerlei sonderfunktionen \n {blub}";// @ deaktiviert sämtliche interpretationen und nimmt den string so wie er da steht

        char Buchstabe = 'P'; // ein einzelnes Zeichen, 2 Byte, Hochkomma

        // Bit
        bool EinzelnesBit; // nur true oder false

        //todo: cast und convert und parse und tostring

    }
}
