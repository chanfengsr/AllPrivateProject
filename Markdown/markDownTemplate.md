# This is an H1
## This is an H2
###### This is an H6

一级标题
===========
二级标题
---------------------

## 列表
*   Red
*   Green
*   Blue

## 引用
> ## This is a header.
> 
> 1.   This is the first list item.
> 2.   This is the second list item.
> 
>> Here's some example code:
> 
>     return shell_exec("echo $input | $markdown_script");

单个回车
视为空格。

连续回车

才能分段。

行尾加两个空格，这里->  
即可段内换行。

*这些文字显示为斜体*

**这些文字显示为粗体**

~~*这些文字删除线*~~

分割线
***

## 选择框
> alt + c to Check
- [ ] todo1 
- [x] todo2

## 表格
 | Left | Center | Right |
 | :--- | :----- | :---- |
 | 1    | 2      | 3     |
 | 45   | 67     | 89    |

## 引用网址

This is [an example](http://example.com/ "Title") inline link.  
[This link](http://example.net/) has no title attribute.  
This is [an example][id] reference-style link.

[id]: http://example.com/  "Optional Title Here"

## 引用特定类型文本
```
<div>   
    <div></div>
    <div></div>
    <div></div>
</div>
```

```javascript
var num = 0;
for (var i = 0; i < 5; i++) {
    num+=i;
}
console.log(num);
```


## 数学公式
$$
f(x) = \int_{-\infty}^\infty
   \hat f(\xi)\,e^{2 \pi i \xi x}
   \,d\xi
$$

## 转义字符
\*literal asterisks\*


## 图片
![Alt text](https://www.chiphell.com/static/image/common/logo.png "Optional title")

![](./logo.png)

![avatar](data:image/png;base64,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)

### base64的图片转换 Python 代码
```python
# 使用python将图片转化为base64字符串
import base64
f=open('723.png','rb') #二进制方式打开图文件
ls_f=base64.b64encode(f.read()) #读取文件内容，转换为base64编码
f.close()
print(ls_f)

# base64字符串转化为图片
import base64
bs='iVBORw0KGgoAAAANSUhEUg....' # 太长了省略
imgdata=base64.b64decode(bs)
file=open('2.jpg','wb')
file.write(imgdata)
file.close()
```

[Markdown语法说明（详解版）](http://www.ituring.com.cn/article/504)