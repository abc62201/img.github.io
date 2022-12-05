import os
import sys
import requests
from tqdm import tqdm
from bs4 import BeautifulSoup
from requests_toolbelt import  *
import time  
  
  
def download(url, file_path):
    # 第一次请求是为了得到文件总大小
    r1 = requests.get(url, stream=True, verify=False)
    total_size = int(r1.headers['Content-Length'])
    file_path=file_path.replace("\\","/")
    # 判断本地文件是否存在，存在则读取文件数据大小
    if os.path.exists(file_path):
        temp_size = os.path.getsize(file_path)  # 本地已经下载的文件大小
    else:
        temp_size = 0
         
    # 对比一下，是不是还没下完
    print(temp_size)
    print(total_size)
# 文件大小一致，跳出循环
    if temp_size != total_size:
        download1(url,file_path)

def download1(url: str, fname: str):
    # 用流stream的方式获取url的数据
    resp = requests.get(url, stream=True)
    # 拿到文件的长度，并把total初始化为0
    total = int(resp.headers.get('content-length', 0))
    # 打开当前目录的fname文件(名字你来传入)
    # 初始化tqdm，传入总数，文件名等数据，接着就是写入，更新等操作了
    with open(fname, 'wb') as file, tqdm(
        desc=fname,
        total=total,
        unit='iB',
        unit_scale=True,
        unit_divisor=1024,
    ) as bar:
        for data in resp.iter_content(chunk_size=1024):
            size = file.write(data)
            bar.update(size)
#关闭一打开的通过文件名程序
def kill(pid):
    # 本函数用于中止传入pid所对应的进程
    if os.name == 'nt':
        # Windows系统
        cmd = 'taskkill /pid ' + str(pid) + ' /f'
        try:
            os.system(cmd)
            #print(pid, 'killed')
        except Exception as e:
           # print(e)
           pass
    elif os.name == 'posix':
        # Linux系统
        cmd = 'kill ' + str(pid)
        try:
            os.system(cmd)
           # print(pid, 'killed')
        except Exception as e:
            pass
           # print(e)
    else:
        pass
       # print('Undefined os.name')

kill('shezhi.exe')