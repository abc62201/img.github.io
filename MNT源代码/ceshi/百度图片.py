import re

import requests

import time #时间模块

from urllib import parse #对汉字进行编码
from bs4 import BeautifulSoup
import os #文件操作
#from fake_useragent import UserAgent #随机生成一个user-agent
class Picture:



    def __init__(self):

        self.name_ = '天空'
        self.sl=0
        self.name = parse.quote(self.name_) #周杰伦 --> 编码

        self.times = str(int(time.time()*1000)) #时间戳-->补全url

        self.url = 'https://image.baidu.com/search/acjson?tn=resultjson_com&logid=8032920601831512061&ipn=rj&ct=201326592&is=&fp=result&fr=&word={}&cg=star&queryWord={}&cl=2&lm=-1&ie=utf-8&oe=utf-8&adpicid=&st=&z=&ic=&hd=&latest=&copyright=&s=&se=&tab=&width=&height=&face=&istype=&qc=&nc=1&expermode=&nojc=&isAsync=&pn={}&rn=30&gsm=1e&{}='

        self.headers = {
        #'User-Agent':UserAgent().random
        'User-Agent':'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/104.0.5112.102 Safari/537.36 Edg/104.0.1293.63',
        }



    #请求30张图片的链接

    def get_one_html(self,url,pn):

        response = requests.get(url=url.format(self.name,self.name, pn, self.times), headers=self.headers).content.decode('utf-8')

        return response



    #请求单张图片内容

    def get_two_html(self,url):

        response = requests.get(url=url, headers=self.headers).content

        return response



    #解析含30张图片的html的内容

    def parse_html(self,regex,html):

        content = regex.findall(html)

        return content

    def file_text_read(self,path):

        f = open(path, 'r', encoding="utf-8")

        x=f.readlines()

        f.close()

        return x

    def file_text_write(self,path,txt):

        f = open(path, 'w', encoding="utf-8")

        f.write(txt)

        f.close()

    def file_text_a(self,path,txt):

        f = open(path, 'a', encoding="utf-8")

        f.write(txt)

        f.close()    

    #主函数

    def run(self,s_name,s_no,cob_txt):
        #判断该目录下是否存在与输入名称一样的文件夹 如果没有则创建 有就不执行if下的创建
        #if not os.path.exists('./{}/'.format(self.name_)):
            #os.mkdir('./{}'.format(self.name_))
        if s_name!="":
            self.name = parse.quote(s_name)
        if cob_txt=="FC图库":
            urls=self.fc_tu_k(s_name,s_no)
            return urls
        else:
            response = self.get_one_html(self.url,0)
            
            regex1 = re.compile('"displayNum":(.*?),')
            num = self.parse_html(regex1,response)[0] #获取总的照片数量
            self.sl=num
        #print('该关键字下一共有{}张照片'.format(num)) #打印总的照片数量
        #判断总数能不能整除30
            if int(num)%30 == 0:
                pn = int(num)//30
            else:
            # 总数量除30是因为每一个链接有30张照片 +2是因为要想range最多取到该数就需要+1
            # 另外的+1是因为该总数除30可能有余数，有余数就需要一个链接 所以要+1
                pn = int(num)//30 + 2
        #for i in range(pn): #遍历每一个含30张图片的链接
            resp = self.get_one_html(self.url, s_no*30)
            regex2 = re.compile('"middleURL":"(.*?)"')
            urls = self.parse_html(regex2,resp) #得到30张图片的链接（30个）     
            return urls
        
    def fc_tu_k(self,s_mame,page):
        fc_k_mame=s_mame
        pages=page
        listurl=[]
        url_fc=f'http://fcpic.nesbbs.com/pic.asp?pagesize=10&gamename={fc_k_mame}&order1=id&order2=desc&chicun=0&dsp=pic&page={pages}'
        response = requests.get(url_fc, headers=self.headers).content.decode('utf-8')
        html_doc=response
        soup=BeautifulSoup(html_doc, 'html.parser')
        img = soup.find_all('img')
        pages=soup.find_all('font')
        for i in range(3, len(img)-1, 1):
            src=img[i].get('src')
            open_src='http://fcpic.nesbbs.com/'+src
            listurl.append(open_src)
        page_NO=pages[len(pages)-1]
        self.sl=int(str(page_NO).split('/')[1].replace("<",""))*10
        return listurl
        #print('共:'+str(page_NO).split('/')[1].replace("<","")+'页')
if __name__ == "__main__":
    spider = Picture()
    x=spider.run('魂斗罗',0,'百度')
    print(x[1])
