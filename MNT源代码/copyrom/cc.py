from xml.dom.minidom import parse
from xml_sql import *
import os
import shutil


def mymovefile(srcfile,dstpath):                       # 移动函数
    if not os.path.isfile(srcfile):
        print ("%s not exist!"%(srcfile))
    else:
        fpath,fname=os.path.split(srcfile)             # 分离文件名和路径
        if not os.path.exists(dstpath):
            os.makedirs(dstpath)                       # 创建路径
        shutil.move(srcfile, dstpath + fname)          # 移动文件
        print ("move %s -> %s"%(srcfile, dstpath + fname))


path='E:/MTN/'
xml_path=path+'rom/game_list/mamelist0.xml'

xml_open(xml_path,"book")
xml_n=read_xml_boos_length()
for i in range(0, xml_n, 1):
    file_path=path+read_xml_line("rom",i).replace("\\","/")
    mymovefile(file_path,'./rom/')
    print(file_path)