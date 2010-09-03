
using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Windows.Forms;
using com.calitha.goldparser.lalr;
using com.calitha.commons;
using com.calitha.goldparser;
using Compilador;
using GoldParser;

namespace com.calitha.goldparser
{

    [Serializable()]
    public class SymbolException : System.Exception
    {
        public SymbolException(string message) : base(message)
        {
        }

        public SymbolException(string message,
            Exception inner) : base(message, inner)
        {
        }

        protected SymbolException(SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }

    }

    [Serializable()]
    public class RuleException : System.Exception
    {

        public RuleException(string message) : base(message)
        {
        }

        public RuleException(string message,
                             Exception inner) : base(message, inner)
        {
        }

        protected RuleException(SerializationInfo info,
                                StreamingContext context) : base(info, context)
        {
        }

    }

    enum SymbolConstants : int
    {
        SYMBOL_EOF               =  0, // (EOF)
        SYMBOL_ERROR             =  1, // (Error)
        SYMBOL_WHITESPACE        =  2, // (Whitespace)
        SYMBOL_MINUS             =  3, // '-'
        SYMBOL_EXCLAM            =  4, // '!'
        SYMBOL_EXCLAMEQ          =  5, // '!='
        SYMBOL_PERCENT           =  6, // '%'
        SYMBOL_AMPAMP            =  7, // '&&'
        SYMBOL_LPARAN            =  8, // '('
        SYMBOL_RPARAN            =  9, // ')'
        SYMBOL_TIMES             = 10, // '*'
        SYMBOL_COMMA             = 11, // ','
        SYMBOL_DOT               = 12, // '.'
        SYMBOL_DIV               = 13, // '/'
        SYMBOL_SEMI              = 14, // ';'
        SYMBOL_LBRACKET          = 15, // '['
        SYMBOL_RBRACKET          = 16, // ']'
        SYMBOL_LBRACE            = 17, // '{'
        SYMBOL_PIPEPIPE          = 18, // '||'
        SYMBOL_RBRACE            = 19, // '}'
        SYMBOL_PLUS              = 20, // '+'
        SYMBOL_LT                = 21, // '<'
        SYMBOL_LTEQ              = 22, // '<='
        SYMBOL_EQ                = 23, // '='
        SYMBOL_EQEQ              = 24, // '=='
        SYMBOL_GT                = 25, // '>'
        SYMBOL_GTEQ              = 26, // '>='
        SYMBOL_BOOLEAN           = 27, // boolean
        SYMBOL_CHAR              = 28, // char
        SYMBOL_CHARACTER         = 29, // character
        SYMBOL_CLASS             = 30, // class
        SYMBOL_ELSE              = 31, // else
        SYMBOL_FALSE             = 32, // false
        SYMBOL_ID                = 33, // id
        SYMBOL_IF                = 34, // if
        SYMBOL_INT               = 35, // int
        SYMBOL_NUM               = 36, // num
        SYMBOL_PROGRAM           = 37, // Program
        SYMBOL_RETURN            = 38, // return
        SYMBOL_STRUCT            = 39, // struct
        SYMBOL_TRUE              = 40, // true
        SYMBOL_VOID              = 41, // void
        SYMBOL_WHILE             = 42, // while
        SYMBOL_ADDEXP            = 43, // <Add Exp>
        SYMBOL_ADDOP             = 44, // <addop>
        SYMBOL_ARG               = 45, // <arg>
        SYMBOL_ASSIGN            = 46, // <assign>
        SYMBOL_BLOCK             = 47, // <block>
        SYMBOL_BOOL_LITERAL      = 48, // <bool_literal>
        SYMBOL_CARG              = 49, // <cArg>
        SYMBOL_CHAR_LITERAL      = 50, // <char_literal>
        SYMBOL_CONDEXP           = 51, // <Cond Exp>
        SYMBOL_CONDOP            = 52, // <condop>
        SYMBOL_CPARAMETER        = 53, // <Cparameter>
        SYMBOL_DECLARATION       = 54, // <declaration>
        SYMBOL_ELSEBLOCK         = 55, // <elseBlock>
        SYMBOL_EXPRESSION        = 56, // <expression>
        SYMBOL_INT_LITERAL       = 57, // <int_literal>
        SYMBOL_ITERATION         = 58, // <iteration>
        SYMBOL_KDECLARATION      = 59, // <kdeclaration>
        SYMBOL_KSTATEMENT        = 60, // <kstatement>
        SYMBOL_KVARDECLARATION   = 61, // <kvarDeclaration>
        SYMBOL_LARG              = 62, // <lArg>
        SYMBOL_LITERAL           = 63, // <literal>
        SYMBOL_LOCATION          = 64, // <location>
        SYMBOL_LPARAMETER        = 65, // <Lparameter>
        SYMBOL_METHODCALL        = 66, // <methodCall>
        SYMBOL_METHODDECLARATION = 67, // <methodDeclaration>
        SYMBOL_MULOP             = 68, // <mulop>
        SYMBOL_MULTEXP           = 69, // <Mult Exp>
        SYMBOL_NEGATEEXP         = 70, // <Negate Exp>
        SYMBOL_OEXPRESSION       = 71, // <oexpression>
        SYMBOL_PARAMETER         = 72, // <parameter>
        SYMBOL_PROGRAM2          = 73, // <program>
        SYMBOL_RELOP             = 74, // <relop>
        SYMBOL_RETURN2           = 75, // <return>
        SYMBOL_SELECTION         = 76, // <selection>
        SYMBOL_SLOCATION         = 77, // <slocation>
        SYMBOL_STATEMENT         = 78, // <statement>
        SYMBOL_STRUCTDECLARATION = 79, // <structDeclaration>
        SYMBOL_TYPE              = 80, // <Type>
        SYMBOL_VALUE             = 81, // <Value>
        SYMBOL_VARDECL1          = 82, // <varDecl 1>
        SYMBOL_VARDECLARATION    = 83  // <varDeclaration>
    };

    enum RuleConstants : int
    {
        RULE_PROGRAM_CLASS_PROGRAM_LBRACE_RBRACE       =  0, // <program> ::= class Program '{' <kdeclaration> '}'
        RULE_KDECLARATION                              =  1, // <kdeclaration> ::= <declaration> <kdeclaration>
        RULE_KDECLARATION2                             =  2, // <kdeclaration> ::= 
        RULE_DECLARATION                               =  3, // <declaration> ::= <structDeclaration>
        RULE_DECLARATION2                              =  4, // <declaration> ::= <varDeclaration>
        RULE_DECLARATION3                              =  5, // <declaration> ::= <methodDeclaration>
        RULE_VARDECLARATION_ID_SEMI                    =  6, // <varDeclaration> ::= <Type> id <varDecl 1> ';'
        RULE_VARDECL1_LBRACKET_NUM_RBRACKET            =  7, // <varDecl 1> ::= '[' num ']'
        RULE_VARDECL1                                  =  8, // <varDecl 1> ::= 
        RULE_STRUCTDECLARATION_STRUCT_ID_LBRACE_RBRACE =  9, // <structDeclaration> ::= struct id '{' <kvarDeclaration> '}'
        RULE_KVARDECLARATION                           = 10, // <kvarDeclaration> ::= <varDeclaration> <kvarDeclaration>
        RULE_KVARDECLARATION2                          = 11, // <kvarDeclaration> ::= 
        RULE_METHODDECLARATION_ID_LPARAN_RPARAN        = 12, // <methodDeclaration> ::= <Type> id '(' <Cparameter> ')' <block>
        RULE_CPARAMETER                                = 13, // <Cparameter> ::= <Lparameter>
        RULE_CPARAMETER2                               = 14, // <Cparameter> ::= 
        RULE_LPARAMETER                                = 15, // <Lparameter> ::= <parameter>
        RULE_LPARAMETER_COMMA                          = 16, // <Lparameter> ::= <parameter> ',' <Lparameter>
        RULE_PARAMETER_ID                              = 17, // <parameter> ::= <Type> id
        RULE_PARAMETER_ID_LBRACKET_RBRACKET            = 18, // <parameter> ::= <Type> id '[' ']'
        RULE_TYPE_INT                                  = 19, // <Type> ::= int
        RULE_TYPE_CHAR                                 = 20, // <Type> ::= char
        RULE_TYPE_BOOLEAN                              = 21, // <Type> ::= boolean
        RULE_TYPE_VOID                                 = 22, // <Type> ::= void
        RULE_TYPE_STRUCT_ID                            = 23, // <Type> ::= struct id
        RULE_TYPE                                      = 24, // <Type> ::= <structDeclaration>
        RULE_BLOCK_LBRACE_RBRACE                       = 25, // <block> ::= '{' <kvarDeclaration> <kstatement> '}'
        RULE_KSTATEMENT                                = 26, // <kstatement> ::= <statement> <kstatement>
        RULE_KSTATEMENT2                               = 27, // <kstatement> ::= 
        RULE_STATEMENT                                 = 28, // <statement> ::= <block>
        RULE_STATEMENT2                                = 29, // <statement> ::= <selection>
        RULE_STATEMENT3                                = 30, // <statement> ::= <iteration>
        RULE_STATEMENT_SEMI                            = 31, // <statement> ::= <return> ';'
        RULE_STATEMENT_SEMI2                           = 32, // <statement> ::= <assign> ';'
        RULE_STATEMENT_SEMI3                           = 33, // <statement> ::= <oexpression> ';'
        RULE_SELECTION_IF_LPARAN_RPARAN                = 34, // <selection> ::= if '(' <expression> ')' <block> <elseBlock>
        RULE_ELSEBLOCK_ELSE                            = 35, // <elseBlock> ::= else <block>
        RULE_ELSEBLOCK                                 = 36, // <elseBlock> ::= 
        RULE_ITERATION_WHILE_LPARAN_RPARAN             = 37, // <iteration> ::= while '(' <expression> ')' <block>
        RULE_RETURN_RETURN                             = 38, // <return> ::= return <oexpression>
        RULE_ASSIGN_EQ                                 = 39, // <assign> ::= <location> '=' <expression>
        RULE_LOCATION_DOT                              = 40, // <location> ::= <slocation> '.' <location>
        RULE_LOCATION                                  = 41, // <location> ::= <slocation>
        RULE_SLOCATION_ID_LBRACKET_RBRACKET            = 42, // <slocation> ::= id '[' <expression> ']'
        RULE_SLOCATION_ID                              = 43, // <slocation> ::= id
        RULE_METHODCALL_ID_LPARAN_RPARAN               = 44, // <methodCall> ::= id '(' <cArg> ')'
        RULE_CARG                                      = 45, // <cArg> ::= <lArg>
        RULE_CARG2                                     = 46, // <cArg> ::= 
        RULE_LARG                                      = 47, // <lArg> ::= <arg>
        RULE_LARG_COMMA                                = 48, // <lArg> ::= <arg> ',' <lArg>
        RULE_ARG                                       = 49, // <arg> ::= <expression>
        RULE_OEXPRESSION                               = 50, // <oexpression> ::= <expression>
        RULE_OEXPRESSION2                              = 51, // <oexpression> ::= 
        RULE_EXPRESSION                                = 52, // <expression> ::= <Cond Exp> <condop> <expression>
        RULE_EXPRESSION2                               = 53, // <expression> ::= <Cond Exp>
        RULE_CONDEXP                                   = 54, // <Cond Exp> ::= <Add Exp> <relop> <Cond Exp>
        RULE_CONDEXP2                                  = 55, // <Cond Exp> ::= <Add Exp>
        RULE_ADDEXP                                    = 56, // <Add Exp> ::= <Mult Exp> <addop> <Add Exp>
        RULE_ADDEXP2                                   = 57, // <Add Exp> ::= <Mult Exp>
        RULE_MULTEXP                                   = 58, // <Mult Exp> ::= <Negate Exp> <mulop> <Mult Exp>
        RULE_MULTEXP2                                  = 59, // <Mult Exp> ::= <Negate Exp>
        RULE_NEGATEEXP_MINUS                           = 60, // <Negate Exp> ::= '-' <Value>
        RULE_NEGATEEXP_EXCLAM                          = 61, // <Negate Exp> ::= '!' <Value>
        RULE_NEGATEEXP                                 = 62, // <Negate Exp> ::= <Value>
        RULE_CONDOP_AMPAMP                             = 63, // <condop> ::= '&&'
        RULE_CONDOP_PIPEPIPE                           = 64, // <condop> ::= '||'
        RULE_RELOP_LTEQ                                = 65, // <relop> ::= '<='
        RULE_RELOP_LT                                  = 66, // <relop> ::= '<'
        RULE_RELOP_GT                                  = 67, // <relop> ::= '>'
        RULE_RELOP_GTEQ                                = 68, // <relop> ::= '>='
        RULE_RELOP_EQEQ                                = 69, // <relop> ::= '=='
        RULE_RELOP_EXCLAMEQ                            = 70, // <relop> ::= '!='
        RULE_ADDOP_PLUS                                = 71, // <addop> ::= '+'
        RULE_ADDOP_MINUS                               = 72, // <addop> ::= '-'
        RULE_MULOP_TIMES                               = 73, // <mulop> ::= '*'
        RULE_MULOP_DIV                                 = 74, // <mulop> ::= '/'
        RULE_MULOP_PERCENT                             = 75, // <mulop> ::= '%'
        RULE_VALUE                                     = 76, // <Value> ::= <literal>
        RULE_VALUE_LPARAN_RPARAN                       = 77, // <Value> ::= '(' <expression> ')'
        RULE_VALUE2                                    = 78, // <Value> ::= <methodCall>
        RULE_VALUE3                                    = 79, // <Value> ::= <location>
        RULE_LITERAL                                   = 80, // <literal> ::= <int_literal>
        RULE_LITERAL2                                  = 81, // <literal> ::= <char_literal>
        RULE_LITERAL3                                  = 82, // <literal> ::= <bool_literal>
        RULE_INT_LITERAL_NUM                           = 83, // <int_literal> ::= num
        RULE_CHAR_LITERAL_CHARACTER                    = 84, // <char_literal> ::= character
        RULE_BOOL_LITERAL_TRUE                         = 85, // <bool_literal> ::= true
        RULE_BOOL_LITERAL_FALSE                        = 86  // <bool_literal> ::= false
    };

    public class MyParser
    {
        private LALRParser parser;

        public MyParser(string filename)
        {
            FileStream stream = new FileStream(filename,
                                               FileMode.Open, 
                                               FileAccess.Read, 
                                               FileShare.Read);
            Init(stream);
            stream.Close();
        }

        public MyParser(string baseName, string resourceName)
        {
            byte[] buffer = ResourceUtil.GetByteArrayResource(
                System.Reflection.Assembly.GetExecutingAssembly(),
                baseName,
                resourceName);
            MemoryStream stream = new MemoryStream(buffer);
            Init(stream);
            stream.Close();
        }

        public MyParser(Stream stream)
        {
            Init(stream);
        }

        private void Init(Stream stream)
        {
            CGTReader reader = new CGTReader(stream);
            parser = reader.CreateNewParser();
            parser.TrimReductions = false;
            parser.StoreTokens = LALRParser.StoreTokensMode.NoUserObject;

            parser.OnTokenError += new LALRParser.TokenErrorHandler(TokenErrorEvent);
            parser.OnParseError += new LALRParser.ParseErrorHandler(ParseErrorEvent);
        }

        public TreeNode Parse(string source)
        {
            NonterminalToken token = parser.Parse(source);
            if (token != null)
            {
                Object obj = CreateObject(token);
                //todo: Use your object any way you like

                return createSyntaxTree(token);
            }

            return null;
        }

        public TreeNode createSyntaxTree(NonterminalToken token)
        {
            TreeNode root = new TreeNode(token.Symbol.Name);
            Token currentToken;

            for (int i = 0; i < token.Tokens.Length; i++)
            {
                currentToken = token.Tokens[i];
                if (currentToken is NonterminalToken)
                {
                    root.Nodes.Add(createSyntaxTree((NonterminalToken)currentToken, new TreeNode(((NonterminalToken)currentToken).Symbol.Name)));

                }
                else
                {
                    root.Nodes.Add(((TerminalToken)currentToken).Symbol.Name);
                }
            }


            return root;
        }

        public TreeNode createSyntaxTree(NonterminalToken token, TreeNode treeNode)
        {
            Token currentToken;
            TreeNode root = treeNode;
            TreeNode child;

            for (int i = 0; i < token.Tokens.Length; i++)
            {
                currentToken = token.Tokens[i];
                if (currentToken is NonterminalToken)
                {
                    child = createSyntaxTree((NonterminalToken)currentToken, new TreeNode(((NonterminalToken)currentToken).Symbol.Name));
                    root.Nodes.Add(child);

                }
                else
                {
                    root.Nodes.Add(((TerminalToken)currentToken).Symbol.Name);
                }
            }


            return root;
        }

        private Object CreateObject(Token token)
        {
            if (token is TerminalToken)
                return CreateObjectFromTerminal((TerminalToken)token);
            else
                return CreateObjectFromNonterminal((NonterminalToken)token);
        }

        private Object CreateObjectFromTerminal(TerminalToken token)
        {
            switch (token.Symbol.Id)
            {
                case (int)SymbolConstants.SYMBOL_EOF :
                //(EOF)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ERROR :
                //(Error)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHITESPACE :
                //(Whitespace)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MINUS :
                //'-'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXCLAM :
                //'!'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXCLAMEQ :
                //'!='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PERCENT :
                //'%'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_AMPAMP :
                //'&&'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LPARAN :
                //'('
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RPARAN :
                //')'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TIMES :
                //'*'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COMMA :
                //','
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DOT :
                //'.'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIV :
                //'/'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SEMI :
                //';'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LBRACKET :
                //'['
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RBRACKET :
                //']'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LBRACE :
                //'{'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PIPEPIPE :
                //'||'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RBRACE :
                //'}'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PLUS :
                //'+'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LT :
                //'<'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LTEQ :
                //'<='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQ :
                //'='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQEQ :
                //'=='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GT :
                //'>'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GTEQ :
                //'>='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_BOOLEAN :
                //boolean
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CHAR :
                //char
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CHARACTER :
                //character
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CLASS :
                //class
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ELSE :
                //else
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FALSE :
                //false
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ID :
                //id
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IF :
                //if
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INT :
                //int
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_NUM :
                //num
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PROGRAM :
                //Program
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RETURN :
                //return
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STRUCT :
                //struct
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TRUE :
                //true
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_VOID :
                //void
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHILE :
                //while
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ADDEXP :
                //<Add Exp>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ADDOP :
                //<addop>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ARG :
                //<arg>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ASSIGN :
                //<assign>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_BLOCK :
                //<block>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_BOOL_LITERAL :
                //<bool_literal>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CARG :
                //<cArg>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CHAR_LITERAL :
                //<char_literal>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CONDEXP :
                //<Cond Exp>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CONDOP :
                //<condop>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CPARAMETER :
                //<Cparameter>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DECLARATION :
                //<declaration>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ELSEBLOCK :
                //<elseBlock>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXPRESSION :
                //<expression>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INT_LITERAL :
                //<int_literal>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ITERATION :
                //<iteration>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_KDECLARATION :
                //<kdeclaration>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_KSTATEMENT :
                //<kstatement>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_KVARDECLARATION :
                //<kvarDeclaration>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LARG :
                //<lArg>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LITERAL :
                //<literal>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LOCATION :
                //<location>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LPARAMETER :
                //<Lparameter>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_METHODCALL :
                //<methodCall>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_METHODDECLARATION :
                //<methodDeclaration>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MULOP :
                //<mulop>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MULTEXP :
                //<Mult Exp>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_NEGATEEXP :
                //<Negate Exp>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_OEXPRESSION :
                //<oexpression>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PARAMETER :
                //<parameter>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PROGRAM2 :
                //<program>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RELOP :
                //<relop>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RETURN2 :
                //<return>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SELECTION :
                //<selection>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SLOCATION :
                //<slocation>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STATEMENT :
                //<statement>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STRUCTDECLARATION :
                //<structDeclaration>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TYPE :
                //<Type>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_VALUE :
                //<Value>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_VARDECL1 :
                //<varDecl 1>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_VARDECLARATION :
                //<varDeclaration>
                //todo: Create a new object that corresponds to the symbol
                return null;

            }
            throw new SymbolException("Unknown symbol");
        }

        public Object CreateObjectFromNonterminal(NonterminalToken token)
        {
            switch (token.Rule.Id)
            {
                case (int)RuleConstants.RULE_PROGRAM_CLASS_PROGRAM_LBRACE_RBRACE :
                //<program> ::= class Program '{' <kdeclaration> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_KDECLARATION :
                //<kdeclaration> ::= <declaration> <kdeclaration>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_KDECLARATION2 :
                //<kdeclaration> ::= 
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DECLARATION :
                //<declaration> ::= <structDeclaration>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DECLARATION2 :
                //<declaration> ::= <varDeclaration>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DECLARATION3 :
                //<declaration> ::= <methodDeclaration>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VARDECLARATION_ID_SEMI :
                //<varDeclaration> ::= <Type> id <varDecl 1> ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VARDECL1_LBRACKET_NUM_RBRACKET :
                //<varDecl 1> ::= '[' num ']'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VARDECL1 :
                //<varDecl 1> ::= 
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STRUCTDECLARATION_STRUCT_ID_LBRACE_RBRACE :
                //<structDeclaration> ::= struct id '{' <kvarDeclaration> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_KVARDECLARATION :
                //<kvarDeclaration> ::= <varDeclaration> <kvarDeclaration>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_KVARDECLARATION2 :
                //<kvarDeclaration> ::= 
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_METHODDECLARATION_ID_LPARAN_RPARAN :
                //<methodDeclaration> ::= <Type> id '(' <Cparameter> ')' <block>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CPARAMETER :
                //<Cparameter> ::= <Lparameter>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CPARAMETER2 :
                //<Cparameter> ::= 
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LPARAMETER :
                //<Lparameter> ::= <parameter>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LPARAMETER_COMMA :
                //<Lparameter> ::= <parameter> ',' <Lparameter>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PARAMETER_ID :
                //<parameter> ::= <Type> id
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PARAMETER_ID_LBRACKET_RBRACKET :
                //<parameter> ::= <Type> id '[' ']'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TYPE_INT :
                //<Type> ::= int
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TYPE_CHAR :
                //<Type> ::= char
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TYPE_BOOLEAN :
                //<Type> ::= boolean
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TYPE_VOID :
                //<Type> ::= void
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TYPE_STRUCT_ID :
                //<Type> ::= struct id
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TYPE :
                //<Type> ::= <structDeclaration>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_BLOCK_LBRACE_RBRACE :
                //<block> ::= '{' <kvarDeclaration> <kstatement> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_KSTATEMENT :
                //<kstatement> ::= <statement> <kstatement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_KSTATEMENT2 :
                //<kstatement> ::= 
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT :
                //<statement> ::= <block>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT2 :
                //<statement> ::= <selection>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT3 :
                //<statement> ::= <iteration>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT_SEMI :
                //<statement> ::= <return> ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT_SEMI2 :
                //<statement> ::= <assign> ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT_SEMI3 :
                //<statement> ::= <oexpression> ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_SELECTION_IF_LPARAN_RPARAN :
                //<selection> ::= if '(' <expression> ')' <block> <elseBlock>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ELSEBLOCK_ELSE :
                //<elseBlock> ::= else <block>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ELSEBLOCK :
                //<elseBlock> ::= 
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ITERATION_WHILE_LPARAN_RPARAN :
                //<iteration> ::= while '(' <expression> ')' <block>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_RETURN_RETURN :
                //<return> ::= return <oexpression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ASSIGN_EQ :
                //<assign> ::= <location> '=' <expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LOCATION_DOT :
                //<location> ::= <slocation> '.' <location>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LOCATION :
                //<location> ::= <slocation>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_SLOCATION_ID_LBRACKET_RBRACKET :
                //<slocation> ::= id '[' <expression> ']'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_SLOCATION_ID :
                //<slocation> ::= id
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_METHODCALL_ID_LPARAN_RPARAN :
                //<methodCall> ::= id '(' <cArg> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CARG :
                //<cArg> ::= <lArg>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CARG2 :
                //<cArg> ::= 
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LARG :
                //<lArg> ::= <arg>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LARG_COMMA :
                //<lArg> ::= <arg> ',' <lArg>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ARG :
                //<arg> ::= <expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OEXPRESSION :
                //<oexpression> ::= <expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OEXPRESSION2 :
                //<oexpression> ::= 
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION :
                //<expression> ::= <Cond Exp> <condop> <expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION2 :
                //<expression> ::= <Cond Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONDEXP :
                //<Cond Exp> ::= <Add Exp> <relop> <Cond Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONDEXP2 :
                //<Cond Exp> ::= <Add Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ADDEXP :
                //<Add Exp> ::= <Mult Exp> <addop> <Add Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ADDEXP2 :
                //<Add Exp> ::= <Mult Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_MULTEXP :
                //<Mult Exp> ::= <Negate Exp> <mulop> <Mult Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_MULTEXP2 :
                //<Mult Exp> ::= <Negate Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_NEGATEEXP_MINUS :
                //<Negate Exp> ::= '-' <Value>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_NEGATEEXP_EXCLAM :
                //<Negate Exp> ::= '!' <Value>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_NEGATEEXP :
                //<Negate Exp> ::= <Value>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONDOP_AMPAMP :
                //<condop> ::= '&&'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONDOP_PIPEPIPE :
                //<condop> ::= '||'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_RELOP_LTEQ :
                //<relop> ::= '<='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_RELOP_LT :
                //<relop> ::= '<'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_RELOP_GT :
                //<relop> ::= '>'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_RELOP_GTEQ :
                //<relop> ::= '>='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_RELOP_EQEQ :
                //<relop> ::= '=='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_RELOP_EXCLAMEQ :
                //<relop> ::= '!='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ADDOP_PLUS :
                //<addop> ::= '+'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ADDOP_MINUS :
                //<addop> ::= '-'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_MULOP_TIMES :
                //<mulop> ::= '*'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_MULOP_DIV :
                //<mulop> ::= '/'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_MULOP_PERCENT :
                //<mulop> ::= '%'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VALUE :
                //<Value> ::= <literal>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VALUE_LPARAN_RPARAN :
                //<Value> ::= '(' <expression> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VALUE2 :
                //<Value> ::= <methodCall>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VALUE3 :
                //<Value> ::= <location>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LITERAL :
                //<literal> ::= <int_literal>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LITERAL2 :
                //<literal> ::= <char_literal>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LITERAL3 :
                //<literal> ::= <bool_literal>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_INT_LITERAL_NUM :
                //<int_literal> ::= num
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CHAR_LITERAL_CHARACTER :
                //<char_literal> ::= character
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_BOOL_LITERAL_TRUE :
                //<bool_literal> ::= true
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_BOOL_LITERAL_FALSE :
                //<bool_literal> ::= false
                //todo: Create a new object using the stored tokens.
                return null;

            }
            throw new RuleException("Unknown rule");
        }

        private void TokenErrorEvent(LALRParser parser, TokenErrorEventArgs args)
        {
            string message = "Token error with input: '"+args.Token.ToString()+"'";
            //todo: Report message to UI?
        }

        private void ParseErrorEvent(LALRParser parser, ParseErrorEventArgs args)
        {
            string message = "Parse error caused by token: '"+args.UnexpectedToken.ToString()+"'";
            //todo: Report message to UI?
        }

    }
}
