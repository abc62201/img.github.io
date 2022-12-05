import requests
import os
from dirandfile import *
from file_textrw import *
from dwfun import *

current_path=os.getcwd()
dw_file_path=[]
dw_file_yn=[]
file_yn="t"
txt_file_path=current_path+r'/update/init_file.txt'
txt_file_txt=file_text_n(txt_file_path)
url=txt_file_txt[0]
version=current_path+'/'+txt_file_txt[1]
txt_filefull_txt=current_path+'/'+txt_file_txt[3]
#更新前先关闭相关软件
kill('shezhi.exe')
kill('jincheng.exe')
kill('mtn_pv_index.exe')
kill('MTN.exe')
kill('abc.exe')
#选则下载程序
for i in range(4, len(txt_file_txt), 1):
    if i%2==0:
        while file_yn != "y" and file_yn != "n":
            file_yn=input(txt_file_txt[i]+'是否下载输入y/n:  ')
        dw_file_yn.append(file_yn)
        file_yn="t"
    else:
        dw_file_path.append(txt_file_txt[i])
#准备下载
if not os.path.exists(version):
#下载运行全部文件
    dw_file_txt=file_text_n(txt_filefull_txt)
    for j in dw_file_txt:
        if j.find('=>')>=0:
            tihname=j.split("=>")
            local_file_patn=current_path+"/"+tihname[1].replace("\\","/")
            url1=url+'/'+tihname[0].replace("\\","/")
        else:
            local_file_patn=current_path+"/"+j.replace("\\","/")
            url1=url+'/'+j.replace("\\","/")
        dir_path(os.path.dirname(local_file_patn))
        download(url1,local_file_patn)
        print(local_file_patn+'下载完成')
    for i in range(1, len(dw_file_yn), 1):
        if dw_file_yn[i]=='y' and os.path.exists(dw_file_path[i]):
            dw_file_txt=file_text_n(dw_file_path[i])
            for j in dw_file_txt:
                local_file_patn=current_path+"/"+j
                dir_path(os.path.dirname(local_file_patn))            
                url1=url+'/'+j
                download(url1,local_file_patn)
                print(local_file_patn+'下载完成')
else:
#下载更新文件
    for i in range(0, len(dw_file_yn), 1):
        if dw_file_yn[i]=='y' and os.path.exists(dw_file_path[i]):
            dw_file_txt=file_text_n(dw_file_path[i])
            for j in dw_file_txt:
#建立文件夹
                if j.find('=>')>=0:
                    tihname=j.split("=>")
                    local_file_patn=current_path+"/"+tihname[1].replace("\\","/")
                    url1=url+'/'+tihname[0].replace("\\","/")
                else:
                    local_file_patn=current_path+"/"+j.replace("\\","/")
                    url1=url+'/'+j.replace("\\","/")
                dir_path(os.path.dirname(local_file_patn))            
                download(url1,local_file_patn)
                print(local_file_patn+'下载完成')

#url=r'https://abc62201.github.io/img.github.io/MTN/version.txt'
#response = requests.get(url)
#print(response.text)