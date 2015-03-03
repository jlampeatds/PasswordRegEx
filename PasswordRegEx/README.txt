This builds and (unit) tests complex password RegEx’s.   

For example, here’s a RegEx that:
•	Enforces the “3 out of 4” upper/lower/number/symbol complexity rule
•	Prevents the use of more than 2 of the same character in a row
•	Requires a password at least 6 characters in length
•	Prevents consecutive numeric sequences like “123” or “369” (keypad)
•	Prevents certain dictionary works like “admin” and “nursing”, using a case- and symbol-insensitive matching scheme (e.g., phrases like “@dm1n” and “pA$5” are automatically treated like “admin” and “pass” and prevented)

(?=^(?!.*(.)\1{2}))((?=.{6})((?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])|(?=.*[a-z])(?=.*[0-9])(?=.*[^a-zA-Z0-9])|(?=.*[A-Z])(?=.*[0-9])(?=.*[^a-zA-Z0-9])|(?=.*[a-z])(?=.*[A-Z])(?=.*[^a-zA-Z0-9]))(^(?!.*(012|123|234|345|456|567|678|789|890|098|987|876|765|654|543|432|321|210|147|741|369|963|025|520|[aA@][dD][mM][iI1!][nN]|[nN][uU][rR][sS5$]))))
