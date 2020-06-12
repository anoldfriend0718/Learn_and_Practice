import numpy as np
from skimage import io,data,color,exposure,transform
from skimage.color import rgb2gray, gray2rgb
from skimage.transform import rescale, resize, downscale_local_mean

def pic_preprocess(imagePath,x_shape=128,y_shape=128):
    rgb = io.imread(imagePath)
    gray = rgb2gray(rgb)
    processed_image=resize(gray,(x_shape,y_shape)) 
    return processed_image

def pic_normalization(pic):
    pic -= pic.min()
    normalized_pic = pic / pic.max()
    normalized_pic = 255*normalized_pic
    return normalized_pic

def batch_process(pic_path,x_shape=128,y_shape=128):
    sk_image = pic_preprocess(pic_path,x_shape,y_shape)
    sk_image = pic_normalization(sk_image).astype(np.uint8)
    image_array = sk_image.flatten()
    return image_array

def pic_show(imagePath):
    img=io.imread(imagePath)
    io.imshow(img)

def pic_array_show(img_array,x_shape,y_shape):
    sk_image=img_array.reshape(x_shape,y_shape)
    io.imshow(sk_image)