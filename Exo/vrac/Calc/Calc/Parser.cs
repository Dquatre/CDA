using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

namespace Calc
{
    public class Parser
    {

        protected string[]? tokens;
        protected int pos;
        protected Stack<int> memory;
        protected Stack<int> stateStack;
        protected Stack<ASTree> forest;

        public Parser()
        {
            memory = new Stack<int>();
            stateStack = new Stack<int>();
            forest = new Stack<ASTree>();
        }

        public static ASTree? Parse(string input)
        {
            Parser p = new Parser();

            if (p.ParseInput(input))
            {
                return p.forest.Pop();
            }
            else
            {
                return null;
            }
        }

        // 30 + 2 * 5
        // ou
        // (3 + 2) * 5

        protected bool HasToken()
        {
            return this.tokens != null && this.pos < this.tokens.Length;
        }

        protected string Token()
        {
            if (this.HasToken())
            {
                return this.tokens[this.pos];
            }

            return string.Empty;
        }

        protected void NextToken()
        {
            if (this.HasToken())
            {
                this.pos++;
            }
        }

        public bool ParseInput(String input)
        {
            string regexp = @"\s*(\+|\*|-|/|%|\(|\))\s*";
            this.tokens = Regex.Split(input.Trim(), regexp)
                            .Where(c => c != String.Empty).ToArray();
            this.pos = 0;

            return this.Arith_Expr();
        }


        // a * x * x   
        protected bool Arith_Expr()
        {
            return this.End_Arith_Expr(this.Term());
        }

        // + b * x + c
        // <END_ARITH_EXPR>  := '+' <ARITH_EXPR>
        //                   := '-' <ARITH_EXPR>
        //                   :=
        protected bool End_Arith_Expr(bool hasTerm)
        {
            if (!hasTerm)
            {
                return false;
            }

            string token = this.Token();

            if (token == "+" || token == "-")
            {
                this.NextToken();
                return this.Arith_Expr();
            }

            return true;
            /*
              switch(token){
                case "+":
                case "-":
                  this.NextToken();
                  return this.Arith_Expr();
                  break;
                default:
                  return true;
                  break;
              }
            */
        }

        // b * x
        // <TERM>            := <UNARY_MINUS> <END_TERM>
        protected bool Term()
        {
            return this.End_Term(this.Unary_Minus());
        }

        // <END_TERM>        := '*' <TERM>
        //                   := '/' <TERM>
        //                   := '%' <TERM>
        //                   :=
        protected bool End_Term(bool hasMinus)
        {
            if (!hasMinus)
            {
                return false;
            }

            string token = this.Token();
            if (token == "*" || token == "/" || token == "%")
            {
                this.NextToken();
                if (this.Term())
                {
                    ASTree right_child = this.forest.Pop();
                    ASTree left_child = this.forest.Pop();
                    this.forest.Push(new ASTree(ASType.BINARYOP, token, new List<ASTree>() { left_child, right_child }));
                    return true;
                }
            }
            return true;
        }

        // -4 ou 4
        // <UNARY_MINUS>     := '-' <UNARY_MINUS>
        //                   := <FACTOR>
        protected bool Unary_Minus()
        {
            if (this.Token() == "-")
            {
                this.Memorize();
                this.NextToken();
                if (this.Unary_Minus())
                {
                    ASTree left_child = this.forest.Pop();
                    this.forest.Push(new ASTree(ASType.UNARYOP, "-", new List<ASTree>() { left_child }));
                    return true;
                }
                this.Recall();
            }

            return this.Factor();
        }

        // b ou x
        // <FACTOR>          := <NUMERIC>
        //                   := '(' <ARITH_EXPR> ')'
        protected bool Factor()
        {
            if (this.Token() == "(")
            {
                this.NextToken();
                bool retour = this.Arith_Expr();
                if (retour && this.Token() == ")")
                {
                    this.NextToken();
                    return true;
                }
                // TO SEE
                return false;
            }

            return this.Numeric();
        }


        // 1 ou 12 ou 1.2 ou 0.1
        // <NUMERIC>        := <INT_PART> <END_NUMERIC>
        // <END_NUMERIC>    := '.' <INT_PART>
        //                  :=
        // <INT_PART>       := <DIGIT> <END_INT_PART>
        // <END_INT_PART>   := <INT_PART>
        //                  :=
        // <DIGIT>          := [0-9]
        protected bool Numeric()
        {
            if (Regex.IsMatch(this.Token(), @"^[0-9]+(\.[0-9]*)?|\.[0-9]+$"))
            {
                // public ASTree(ASType type, string root="", List<ASTree>? children=null)
                this.forest.Push(new ASTree(ASType.NUMERIC, this.Token()));
                this.NextToken();
                return true;
            }

            return false;
        }

        protected void Memorize()
        {
            this.memory.Push(this.pos);
            this.stackStates.Push(this.forest.Count);
        }

        protected void Recall()
        {
            this.pos = this.memory.Pop();
            int state = this.stackStates.Pop();
            while (this.forest.Count > state)
            {
                this.forest.Pop();
            }
        }
    }
}