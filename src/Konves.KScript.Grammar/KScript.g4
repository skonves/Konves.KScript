grammar KScript;

/*
 * Parser Rules
 */

root : expression EOF ;

literal : NAMED_TOKEN | TRUE | FALSE | NUMBER | STRING | NOW | NULL | OPEN_PAREN literal CLOSE_PAREN ;

expression : TRUE | FALSE | betweenExpression | inExpression | expression AND expression | expression OR expression | relationalExpression | OPEN_PAREN expression CLOSE_PAREN | NOT expression ;

betweenExpression : literal BETWEEN literal AND literal;

inExpression : literal IN list ;

relationalExpression : literal (GT | GT_ET | LT | LT_ET | EQ | NE ) literal ;

list : OPEN_BRACKET literal (COMMA literal)* CLOSE_BRACKET ;

/*
 * Lexer Rules
 */

STRING : '"' ~["]* '"' | '\'' ~[~']* '\'';
NAMED_TOKEN : '{' ~[\}]* '}' ;

AND : A N D ;

IN : I N | I S [ \n\t\r]+ I N;
BETWEEN : B E T W E E N ;

NOT : N O T ;
NOW : N O W ;
NULL : N U L L;
OR : O R ;

TRUE : T R U E ;
FALSE : F A L S E ;

COMMA : ',' ;

OPEN_BRACKET : '[' ;
CLOSE_BRACKET : ']' ;

OPEN_PAREN : '(' ;
CLOSE_PAREN : ')' ;

NUMBER : DIGIT+ ('.' DIGIT+)? ;

GT : '>' ;
GT_ET : '>=' ;
LT : '<' ;
LT_ET : '<=' ;
EQ : '=' | '==' | I S ;
NE : '!=' | '<>' | I S [ \n\t\r]+ N O T;

fragment DIGIT : [0-9] ;

fragment A : ('A'|'a') ;
fragment B : ('B'|'b') ;
fragment C : ('C'|'c') ;
fragment D : ('D'|'d') ;
fragment E : ('E'|'e') ;
fragment F : ('F'|'f') ;
fragment G : ('G'|'g') ;
fragment H : ('H'|'h') ;
fragment I : ('I'|'i') ;
fragment J : ('J'|'j') ;
fragment K : ('K'|'k') ;
fragment L : ('L'|'l') ;
fragment M : ('M'|'m') ;
fragment N : ('N'|'n') ;
fragment O : ('O'|'o') ;
fragment P : ('P'|'p') ;
fragment Q : ('Q'|'q') ;
fragment R : ('R'|'r') ;
fragment S : ('S'|'s') ;
fragment T : ('T'|'t') ;
fragment U : ('U'|'u') ;
fragment V : ('V'|'v') ;
fragment W : ('W'|'w') ;
fragment X : ('X'|'x') ;
fragment Y : ('Y'|'y') ;
fragment Z : ('Z'|'z') ;

WS: [ \n\t\r]+ -> skip;
