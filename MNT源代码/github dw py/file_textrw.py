import os

#读取txt文件内容
def file_text_read(path):
    f = open(path, 'r',encoding='UTF-8')
    x=f.readlines()
    f.close()
    return x

#写入txt文件内容
def file_text_write(path,txt):
    f = open(path, 'w')
    f.write(txt)
    f.close()

#追加txt文件内容
def file_text_a(path,txt):
    f = open(path, 'a')
    f.write(txt)
    f.close()

#去掉换行符
def file_text_n(path):
    x = []
    for i in file_text_read(path):
        i = i.replace("\n","")
        if i!= "":
            x.append(i)
    return x

def zip_size_no(size):
    size_no="".join(list(filter(str.isdigit,size)))
    size_str=size.replace(size_no,"")
    x=[size_no,size_str]
    return x

