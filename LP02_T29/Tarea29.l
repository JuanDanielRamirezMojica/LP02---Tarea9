%{
/* definitions of manifest constants */
#define LT 300
#define LE 301
#define EQ 302   /* 'igual a' */
#define NE 303
#define GT 304
#define GE 305
#define IF 306
#define THEN 307
#define ELSE 308
#define ID 309
#define NUMBER 310
#define RELOP 311
#define KW 312  /* New category for keywords */
%}

/* regular definitions */
delim   [ \t\n]+
ws      {delim}
letter  [A-Za-z]
digit   [0-9]
id      {letter}({letter}|{digit})*
number  {digit}+(\.{digit}+)?(E[+-]?{digit}+)?

%%
/* Ignorar espacios en blanco */
ws          { /* no action and no return */ }

/* Manejo de palabras clave */
"if"        { yylval = IF; return(KW); }
"then"      { yylval = THEN; return(KW); }
"else"      { yylval = ELSE; return(KW); }

/* Identificadores */
{id}        { yylval = (int) installID(); return(ID); }

/* Números */
{number}    { yylval = (int) installNum(); return(NUMBER); }

/* Operadores relacionales */
"<"         { yylval = LT; return(RELOP); }
"<="        { yylval = LE; return(RELOP); }
"="         { yylval = EQ; return(RELOP); } /* Igual a, asignado como 302 */
"<>"        { yylval = NE; return(RELOP); }
">"         { yylval = GT; return(RELOP); }
">="        { yylval = GE; return(RELOP); }
%%
