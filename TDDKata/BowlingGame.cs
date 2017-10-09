using System;
using System.Collections.Generic;
using System.Text;

namespace CodeKata {
    public class BowlingGame {
        private int[] _rolls = new int[21];
        private int _currentRoll = 0;

        public void Roll(int pins) {
            _rolls[_currentRoll] = pins;
            _currentRoll++;
        }

        public int Score() {
            int score = 0;
            int roll = 0;

            for (int frame = 0; frame < 10; frame++) {
                int frameScore = GetFrameScore(roll);
                score += frameScore;
                if (frameScore == 10) {
                    if (_rolls[roll] == 10) {
                        score += GetStrikeBonus(roll);
                        roll++;
                    } else {
                        score += GetSpareBonus(roll);
                        roll += 2;
                    }
                } else {
                    roll += 2;
                }
            }

            return score;
        }

        public int GetFrameScore(int roll) {
            if (_rolls[roll] != 10) {
                return _rolls[roll] + _rolls[roll + 1];
            }
            return 10;
        }

        public int GetStrikeBonus(int roll) {
            return _rolls[roll + 1] + _rolls[roll + 2];
        }

        public int GetSpareBonus(int roll) {
            return _rolls[roll + 2];
        }
    }
}
