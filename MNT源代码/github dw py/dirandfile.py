import os
from os.path import join, getsize

#建立文件夹
def dir_path(path):
    if not os.path.exists(path):
        os.makedirs(path)

#是文件还是文件夹    
def if_file(path):
    x=os.path.isdir(path)
    if(x):
        return "dir"
    else:
        return "file"
		
#获取文件名
def file_name(path):
    x=os.path.basename(path)
    return x

#获取文件扩展名
def file_exec(path):
    x=file_name(path)
    file_exec_name=x.split(".")[len(x.split("."))-1]
    return file_exec_name
	
#获取文件名不带扩展名	
def file_name_noexec(path):
    x=file_name(path)
    c=file_exec(path)
    noexec=x.replace("."+c,"")
    return noexec
	
#获取文件大小	
def file_size(path):
    size=0
    if(if_file(path)=='file'):
        size=os.path.getsize(path)
        return size
    else:
        for root, dirs, files in os.walk(path):
            size += sum([getsize(join(root, name)) for name in files])
        return size

#获取检查文件名是否有下列字符
def file_name_check(path):
    name_check='~!@#$%^&*()-+=[]{}\/<>,.\'"; ~！@#￥%……&*（）——=：“？?。，'
    x=file_name_noexec(path)
    n=len(x)
    for i in range(0,len(x),1):
        if name_check.find(x[i]) != -1:
            t = 0
            break
        else:
            t = 1
    return t


