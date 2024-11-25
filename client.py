from zeep import Client
from zeep.transports import Transport
from requests import Session
import requests
from requests.packages.urllib3.exceptions import InsecureRequestWarning

# Suprimir advertencias de verificación de certificados
requests.packages.urllib3.disable_warnings(InsecureRequestWarning)

# Crear una sesión y desactivar la verificación del certificado
session = Session()
session.verify = False  # Desactivar verificación del certificado

# URL del WSDL del servicio SOAP 
wsdl = 'https://localhost:44363/LibrosService.asmx?wsdl'
client = Client(wsdl, transport=Transport(session=session))

def agregar_libro(titulo, autor, anio_publicacion):
    try:
        print(f'Titulo: {titulo}, Autor: {autor}, Año de Publicación: {anio_publicacion}') 
        response = client.service.AgregarLibro(titulo, autor, int(anio_publicacion))
        print(response)  
    except Exception as e:
        print(f'Error al agregar libro: {e}')

def actualizar_libro(id_libro, titulo, autor, anio_publicacion):
    try:
        print(f'ID: {id_libro}, Titulo: {titulo}, Autor: {autor}, Año de Publicación: {anio_publicacion}') 
        response = client.service.ActualizarLibro(id_libro, titulo, autor, int(anio_publicacion))
        print(response) 
    except Exception as e:
        print(f'Error al actualizar libro: {e}')

def eliminar_libro(id_libro):
    try:
        print(f'Eliminando libro con ID: {id_libro}')  
        response = client.service.EliminarLibro(id_libro)
        print(response)  
    except Exception as e:
        print(f'Error al eliminar libro: {e}')

def obtener_libros():
    try:
        response = client.service.ObtenerLibros()  #Lista de libros
        if response:  #Verifica si hay libros
            for libro in response:  #Recorre la lista de libros
                print(f'ID: {libro.Id}, Titulo: {libro.Titulo}, Autor: {libro.Autor}, Año de Publicación: {libro.AnioPublicacion}')
        else:
            print("No hay libros disponibles.")
    except Exception as e:
        print(f'Error al obtener los libros: {e}')

def obtener_libro_por_id(id_libro):
    try:
        response = client.service.ObtenerLibros()
        # Buscar el libro con el ID especificado en la lista de libros
        libro_encontrado = next((libro for libro in response if str(libro.Id) == id_libro), None)
        if libro_encontrado:
            print(f'ID: {libro_encontrado.Id}, Titulo: {libro_encontrado.Titulo}, Autor: {libro_encontrado.Autor}, Año de Publicación: {libro_encontrado.AnioPublicacion}')
        else:
            print(f'No se encontró el libro con ID: {id_libro}')
    except Exception as e:
        print(f'Error al obtener el libro por ID: {e}')


if __name__ == "__main__":
    #AGREGAR LIBRO
        #agregar_libro('Dos años de soledad', 'Gabriel García Márquez', 1967)

    #EDITAR LIBRO
        #id_existente = '3d7049c8-bdb5-4c7c-bc41-67b902e54e29'  
        #actualizar_libro(id_existente, 'Actualizado', 'Gabriel García Márquez', 1968)

    #ELIMINAR LIBRO
        #id_existente = 'id-libro-aqui'
        #eliminar_libro(id_existente)
        
    #OBTENER LIBRO POR ID
        #id_libro = '3d7049c8-bdb5-4c7c-bc41-67b902e54e29'
        #obtener_libro_por_id(id_libro)

    #OBTENER TODOS LOS LIBROS
        #obtener_libros()