from xml.dom.minidom import parse
import os



def xml_open(xml_path,xml_node):
    global xml_rw_zip_xml_file
    global xml_book
    global doc_zip_xml
    if(os.path.exists(xml_path)):
        xml_rw_zip_xml_file = parse(xml_path)
        doc_zip_xml = xml_rw_zip_xml_file.documentElement
        xml_book = doc_zip_xml.getElementsByTagName(xml_node)
    
def read_xml_line(xml_node,i):
    global xml_rw_zip_xml_file
    global xml_book
    if(i<xml_book.length):
        xml_file_path=xml_book[i].getElementsByTagName(xml_node)[0]
        x=xml_file_path.childNodes[0].nodeValue
        return x
    else:
        x='超出范围'
        return x
def read_xml_boos_length():
    global xml_rw_zip_xml_file
    global xml_book
    return xml_book.length
def modify_xml_line(xml_node,i):
    global xml_rw_zip_xml_file
    global xml_book
    if(i<xml_book.length):
        xml_file_path=xml_book[i].getElementsByTagName(xml_node)[0]
        xml_file_path.childNodes[0].nodeValue="完成"

def xml_sevr(xml_path):
    global xml_rw_zip_xml_file
    global xml_book
    f=open(xml_path,"w",encoding="utf-8")
    xml_rw_zip_xml_file.writexml(f,encoding="utf-8")
    f.close()
def update_xml_length(update_node,i):
    global xml_rw_zip_xml_file
    global xml_book
    update_file_path=xml_book[i].getElementsByTagName(update_node)
    return update_file_path.length
def update_xml_path(update_node,i,j):
    global xml_rw_zip_xml_file
    global xml_book
    update_file_path=xml_book[i].getElementsByTagName(update_node)
    return update_file_path[j].childNodes[0].nodeValue



