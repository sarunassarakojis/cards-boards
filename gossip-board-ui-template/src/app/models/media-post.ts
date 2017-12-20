import {TextPost} from './text-post';
import {ImagePath} from './image-path';

export class MediaPost extends TextPost {
  imageUrls: Array<ImagePath>;
  videoUrl: string;
}
