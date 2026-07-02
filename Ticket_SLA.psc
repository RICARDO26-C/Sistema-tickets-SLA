Algoritmo SLA_Ticket
	Escribir "================================================="
	Escribir "================= SLA - Ticket =================="
	Escribir "================================================="
	
	Escribir "Ingresa el Dia de creacion (1=Lunes ... 7=Domingo): "
    Leer diaInicio
	
    Escribir "Ingresa la Hora de creacion (0-23): "
    Leer horaInicio
	
    Escribir "Ingresa el Dia de resolucion (1=Lunes ... 7=Domingo): "
    Leer diaFin
	
    Escribir "Ingresa la Hora de resolucion (0-23): "
    Leer horaFin
	
    horas <- 0
	
    Para i <- diaInicio Hasta diaFin
        Si i <> 6 Y i <> 7 Entonces
            Si i = diaInicio Y i = diaFin Entonces
                horas <- horaFin - horaInicio
            Sino
                Si i = diaInicio Entonces
                    horas <- horas + (17 - horaInicio)
                Sino
                    Si i = diaFin Entonces
                        horas <- horas + (horaFin - 9)
                    Sino
                        horas <- horas + 8
                    FinSi
                FinSi
            FinSi
        FinSi
    FinPara
	
    Escribir "Horas laborales: ", horas
	
    Si horas <= 8 Entonces
        Escribir "SLA: Cumplido"
    Sino
        Escribir "SLA: Incumplido: ", horas - 8, " horas de m�s"
    FinSi
FinAlgoritmo
