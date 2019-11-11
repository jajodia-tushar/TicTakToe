using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TicTakToe.Controllers
{

    public class GameController : ApiController
    {
        static int player = 1;
        static List<List<char>> board = new List<List<char>>()
        {
            new List<char>()
            {
                '-','-','-'
            },
            new List<char>()
            {
                '-','-','-'
            },
            new List<char>()
            {
                '-','-','-'
            }
        };

        // GET: api/Game
        public IEnumerable<IEnumerable<char>> Get()
        {
            return board;
        }

        // GET: api/Game/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Game
        public string Post([FromBody]string value)
        {
            string[] x = value.Split('-');
            int i = int.Parse(x[0]);
            int j = int.Parse(x[1]);

            if (player == 1)
            {
                if (board[i][j] == '-')
                {
                    board[i][j] = 'x';
                    if (IsWinningCondition('x'))
                        return "player 1 wins";
                    player = 2;
                }
                else
                    return "Invalid Move";
            }
            else if (player == 2)
            {
                if (board[i][j] == '-')
                {
                    board[i][j] = 'o';
                    player = 1;
                    if (IsWinningCondition('o'))
                        return "player 2 wins";
                }
                else
                    return "Invalid Move";
            }

            if (IsDraw())
                return "Game is Draw";

            return "Move Done";
        }

        private bool IsDraw()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i][j] == '-')
                        return false;
                }
            }
            return true;
        }

        private bool IsWinningCondition(char ch)
        {
            for (int i = 0; i < 3; i++)
            {
                if (board[0][i] == ch && board[1][i] == ch && board[2][i] == ch)
                    return true;

                if (board[i][0] == ch && board[i][1] == ch && board[i][2] == ch)
                    return true;
            }

            if ((board[0][0] == ch && board[1][1] == ch && board[2][2] == ch) ||
               (board[0][2] == ch && board[1][1] == ch && board[2][0] == ch))
                return true;

            return false;

        }

        // PUT: api/Game/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Game/5
        public void Delete(int id)
        {
            board = new List<List<char>>()
        {
            new List<char>()
            {
                '-','-','-'
            },
            new List<char>()
            {
                '-','-','-'
            },
            new List<char>()
            {
                '-','-','-'
            }
            };
        }
    }
}
