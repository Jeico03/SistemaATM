Proceso SistemaATM

    Definir opcion Como Entero
    Definir titular Como Cadena
    Definir numeroCuenta Como Cadena
    Definir cuentaActiva Como Logico
    Definir saldo Como Real
    Definir monto Como Real
    
    titular      <- "Jeico Arias"
    numeroCuenta <- "73492"
    cuentaActiva <- Verdadero
    saldo        <- 10000.00
    
    Repetir
        Escribir ""
        Escribir "=== CAJERO AUTOMATICO ==="
        Escribir "Titular: ", titular
        Escribir "Cuenta:  ", numeroCuenta
        Escribir "Saldo actual: RD$", saldo
        Escribir "---------------------------"
        Escribir "1. Consultar saldo"
        Escribir "2. Depositar"
        Escribir "3. Retirar"
        Escribir "4. Salir"
        Escribir "Seleccione una opcion: "
        Leer opcion
        
        Segun opcion Hacer
            1:
                Si cuentaActiva = Falso Entonces
                    Escribir "Operacion rechazada: la cuenta no esta activa."
                SiNo
                    Escribir "Su saldo actual es: RD$", saldo
                FinSi
                
            2:
                Si cuentaActiva = Falso Entonces
                    Escribir "Operacion rechazada: la cuenta no esta activa."
                SiNo
                    Escribir "Ingrese el monto a depositar: "
                    Leer monto
                    
                    Si monto <= 0 Entonces
                        Escribir "Operacion rechazada: el monto debe ser mayor que cero."
                    SiNo
                        saldo <- saldo + monto
                        Escribir "Deposito realizado. Nuevo saldo: RD$", saldo
                    FinSi
                FinSi
                
            3:
                Si cuentaActiva = Falso Entonces
                    Escribir "Operacion rechazada: la cuenta no esta activa."
                SiNo
                    Escribir "Ingrese el monto a retirar: "
                    Leer monto
                    
                    Si monto <= 0 Entonces
                        Escribir "Operacion rechazada: el monto debe ser mayor que cero."
                    SiNo
                        Si monto > saldo Entonces
                            Escribir "Operacion rechazada: saldo insuficiente."
                            Escribir "Saldo disponible: RD$", saldo
                        SiNo
                            saldo <- saldo - monto
                            Escribir "Retiro realizado. Nuevo saldo: RD$", saldo
                        FinSi
                    FinSi
                FinSi
                
            4:
                Escribir "Gracias por usar el cajero. Hasta luego."
                
            De Otro Modo:
                Escribir "Error: opcion no valida. Debe elegir del 1 al 4."
                
        FinSegun
        
    Hasta Que opcion = 4
    
FinProceso